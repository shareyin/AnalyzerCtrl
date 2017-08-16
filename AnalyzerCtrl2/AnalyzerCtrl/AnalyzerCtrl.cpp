// AnalyzerCtrl.cpp: implementation of the CAnalyzerCtrl class.
//
//////////////////////////////////////////////////////////////////////

#include "stdafx.h"
#include "AnalyzerCtrl.h"
#include "visa.h"
//#include "OBUParamTestDlg.h"
#define ANALYZERCTRL_DLL

#pragma comment(lib, "visa32.lib")


#ifdef _DEBUG
#undef THIS_FILE
static char THIS_FILE[]=__FILE__;
#define new DEBUG_NEW
#endif

ViSession m_VisDefaultRM_ANA;
ViSession m_VisDefaultRM_SIG;
ViSession m_VisDefaultRM_SIG1;
ViSession m_Vis_ANA;	// 频谱仪
ViSession m_Vis;
ViSession m_Vis_SIG;	// 信号源
ViSession m_Vis_SIG1;	// 信号源2号
ViStatus m_ViStatus;
BOOL m_bOpened;
//////////////////////////////////////////////////////////////////////
// Construction/Destruction
//////////////////////////////////////////////////////////////////////
//BEGIN_MESSAGE_MAP(CAnalyzerCtrl, CWinApp)
//////{{AFX_MSG_MAP(CAgilentControlApp)
////// NOTE - the ClassWizard will add and remove mapping macros here.
//////    DO NOT EDIT what you see in these blocks of generated code!
//////}}AFX_MSG_MAP
//END_MESSAGE_MAP()
CAnalyzerCtrl::CAnalyzerCtrl()
{
	m_ViStatus = NULL;
	m_bOpened = FALSE;
}
CAnalyzerCtrl theAPP;
__declspec(dllexport) BOOL IsOpened() {return m_bOpened;}
__declspec(dllexport) BOOL OpenAnalyzer(char * DevName, int DevNo)
{
	switch(DevNo)
	{
	case 0:			// 频谱仪 N9010A
		m_ViStatus = viOpenDefaultRM(&m_VisDefaultRM_ANA);
		if (m_ViStatus != 0)
		{
			return FALSE;
		}
		m_ViStatus = viOpen(m_VisDefaultRM_ANA, DevName, VI_NULL,VI_NULL, &m_Vis_ANA);  //alias,USB Device
		if (m_ViStatus != 0)
		{
			return FALSE;
		}
		m_bOpened = TRUE;
		break;
	case 1:		// 信号源 E4438C
		m_ViStatus = viOpenDefaultRM(&m_VisDefaultRM_SIG);
		if (m_ViStatus != 0)
		{
			return FALSE;
		}
		m_ViStatus = viOpen(m_VisDefaultRM_SIG, DevName, VI_NULL,VI_NULL, &m_Vis_SIG);  //alias,USB Device
		if (m_ViStatus != 0)
		{
			return FALSE;
		}
		m_bOpened = TRUE;
		break;
	case 2:		// 信号源2号 E4438C
		m_ViStatus = viOpenDefaultRM(&m_VisDefaultRM_SIG1);
		if (m_ViStatus != 0)
		{
			return FALSE;
		}
		m_ViStatus = viOpen(m_VisDefaultRM_SIG1, DevName, VI_NULL,VI_NULL, &m_Vis_SIG1);  //alias,USB Device
		if (m_ViStatus != 0)
		{
			return FALSE;
		}
		break;
	default:
		break;
	}	
	return TRUE;
}

__declspec(dllexport) void CloseAnalyzer(int DevNo)
{
	switch(DevNo)
	{
	case 0:			// 频谱仪 N9010A
		viClose(m_Vis_ANA);
		viClose(m_VisDefaultRM_ANA);
		break;
	case 1:		// 信号源 E4438C
		viClose(m_Vis_SIG);
		viClose(m_VisDefaultRM_SIG);
		break;
	case 2:	// 信号源2号 E4438C
		viClose(m_Vis_SIG1);
		viClose(m_VisDefaultRM_SIG1);
		break;
	default:
		break;
	}
	m_bOpened = FALSE;
}

__declspec(dllexport) void ExecOrder_ANA(CString aOrder)
{
	viPrintf(m_Vis_ANA,(LPSTR)(LPCTSTR)aOrder);	
}

void CAnalyzerCtrl::ExecOrder_SIG(CString aOrder)
{
	viPrintf(m_Vis_SIG,(LPSTR)(LPCTSTR)aOrder);	
}

void CAnalyzerCtrl::ExecOrder_SIG1(CString aOrder)
{
	viPrintf(m_Vis_SIG1,(LPSTR)(LPCTSTR)aOrder);	
}

extern __declspec(dllexport) BOOL SetAnalyzer(float fFreq/* =5.79f */, int iSpan/* =10 */, int iAmptdYS/* =-10 */, 
								float fMark/* =5.79f */, int iBandSpan/* =2 */, int iAveNum/* =20 */)
{
	CString str;

	viPrintf(m_Vis_ANA,":SYST:PRES\n");									// Mode Preset

	str.Format(_T("FREQ:CENT %0.2f GHz\n"),fFreq);						// Set FREQ Center Frequency
	viPrintf(m_Vis_ANA,(LPSTR)(LPCTSTR)str);				

	str.Format(_T("FREQ:SPAN %d MHz\n"),iSpan);							// Set SPAN
	viPrintf(m_Vis_ANA,(LPSTR)(LPCTSTR)str);				

	// 设置参考电平
	str.Format(_T("DISP:WIND:TRAC:Y:RLEV %d dBm\n"),iAmptdYS);			// Set FREQ Center Frequency
	viPrintf(m_Vis_ANA,(LPSTR)(LPCTSTR)str);				

	viPrintf(m_Vis_ANA,"CALC:MARK:FUNC BPOW\n");						// Marker Function->Band Interval Power

	str.Format(_T(":CALCulate:MARKer1:X %0.2f GHz\n"),fMark);			// Set Mark Frequency
	viPrintf(m_Vis_ANA,(LPSTR)(LPCTSTR)str);					

// 	str.Format(":CALCulate:MARKer1:X %0.2f GHz\n",fMark);			// Set Mark Frequency
// 	viPrintf(m_Vis_ANA,(LPSTR)(LPCTSTR)str);					

	str.Format(_T(":CALC:MARK1:FUNC:BAND:SPAN %d MHz\n"),iBandSpan);	// Set Band Adjust->Band SPAN
	viPrintf(m_Vis_ANA,(LPSTR)(LPCTSTR)str);				

	//viPrintf(m_Vis_ANA,"TRAC2:TYPE AVER\n");								// Trace->Trace Average				

	viPrintf(m_Vis_ANA,":TRACe1:TYPE AVERage\n");

	str.Format(_T(":AVERage:COUNt %d\n"),iAveNum);						// Set Meas Setup->Average Number
	viPrintf(m_Vis_ANA,(LPSTR)(LPCTSTR)str);				
	return TRUE;
}


extern __declspec(dllexport) double GetBandPower()
{
	double dBuf[2];
	double dResult;
	viPrintf (m_Vis_ANA, "CALC:MARK:Y?\n");             //Read Power
	

	m_ViStatus = viScanf (m_Vis_ANA, "%lf,%lf", &dBuf[0], &dBuf[1]);
	dResult = dBuf[0];
	
	if (m_ViStatus!=0)
	{
		m_ViStatus = viPrintf (m_Vis_ANA, "READ:CHP?\n");             //Read Power
		m_ViStatus = viScanf (m_Vis_ANA, "%lf,%lf", &dBuf[0], &dBuf[1]);
		dResult = dBuf[0];
	}
	
	return dResult;
}


void CAnalyzerCtrl::GetMarkerVal(double * x,double * y)
{
	double dBuf[2];
    viPrintf (m_Vis_ANA, "CALC:MARK:Y?\n"); 
	m_ViStatus = viScanf (m_Vis_ANA, "%lf,%lf", &dBuf[0], &dBuf[1]);
	*y = dBuf[0];
	if (m_ViStatus!=0)
	{
		m_ViStatus = viPrintf (m_Vis_ANA, "READ:CHP?\n");             //Read Power
		m_ViStatus = viScanf (m_Vis_ANA, "%lf,%lf", &dBuf[0], &dBuf[1]);
		*y = dBuf[0];
	}
	viPrintf (m_Vis_ANA, "CALC:MARK:X?\n"); 
	m_ViStatus = viScanf (m_Vis_ANA, "%lf,%lf", &dBuf[0], &dBuf[1]);
	*x = dBuf[0];
	if (m_ViStatus!=0)
	{
		m_ViStatus = viPrintf (m_Vis_ANA, "READ:CHP?\n");             //Read Power
		m_ViStatus = viScanf (m_Vis_ANA, "%lf,%lf", &dBuf[0], &dBuf[1]);
		*x = dBuf[0];
	}

}

void CAnalyzerCtrl::GetIntervalVal(double * x,double * y)
{
	double dBuf[2];

	memset(dBuf, 0x00, 2);

    viPrintf (m_Vis_ANA, "CALC:Left:Y?\n"); 
	m_ViStatus = viScanf (m_Vis_ANA, "%lf,%lf", &dBuf[0], &dBuf[1]);
	*y = dBuf[0];
	if (m_ViStatus!=0)
	{
		m_ViStatus = viPrintf (m_Vis_ANA, "READ:Span?\n");             //Read Power
		m_ViStatus = viScanf (m_Vis_ANA, "%lf,%lf", &dBuf[0], &dBuf[1]);
		*y = dBuf[0];
	}
	viPrintf (m_Vis_ANA, "CALC:Left:X?\n"); 
	m_ViStatus = viScanf (m_Vis_ANA, "%lf,%lf", &dBuf[0], &dBuf[1]);
	*x = dBuf[0];
	if (m_ViStatus!=0)
	{
		m_ViStatus = viPrintf (m_Vis_ANA, "READ:Span?\n");             //Read Power
		m_ViStatus = viScanf (m_Vis_ANA, "%lf,%lf", &dBuf[0], &dBuf[1]);
		*x = dBuf[0];
	}
}


__declspec(dllexport) double GetBandWidth()
{
	double dBuf[2];
	double dResult;
	viPrintf (m_Vis_ANA, ":FETCH:OBWidth:OBWidth?\n"); 
	m_ViStatus = viScanf (m_Vis_ANA, "%lf,%lf", &dBuf[0], &dBuf[1]);
	dResult = dBuf[0];
	if (m_ViStatus != 0)
	{
		m_ViStatus = viPrintf (m_Vis_ANA, "READ:CHP?\n");             //Read Power
		m_ViStatus = viScanf (m_Vis_ANA, "%lf,%lf", &dBuf[0], &dBuf[1]);
		dResult = dBuf[0];
	}	
	return dResult;
}


void CAnalyzerCtrl::GetBER(double *Power, unsigned long *Tbits, unsigned long *Ebits)
{
	double dBuf[2];
	unsigned long RBuf[2];

	memset(dBuf, 0x00, 2);
	memset(RBuf, 0, 2);

	m_ViStatus = viPrintf (m_Vis_SIG, ":AMPL?\n");             //Read Power
	m_ViStatus = viScanf (m_Vis_SIG, "%lf,%lf", &dBuf[0], &dBuf[1]);
	*Power = dBuf[0];

	m_ViStatus = viPrintf (m_Vis_SIG, ":DATA? BITC\n");         //Read Total Bits
	m_ViStatus = viScanf (m_Vis_SIG, "%d,%d", &RBuf[0], &RBuf[1]);
	*Tbits = RBuf[0];

	m_ViStatus = viPrintf (m_Vis_SIG, ":DATA? BEC\n");         //Read Error Bits
	m_ViStatus = viScanf (m_Vis_SIG, "%d,%d", &RBuf[0], &RBuf[1]);
	*Ebits = RBuf[0];
}