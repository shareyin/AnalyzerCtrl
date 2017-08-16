// AnalyzerCtrl.h: interface for the CAnalyzerCtrl class.
//
//////////////////////////////////////////////////////////////////////

#if !defined(AFX_ANALYZERCTRL_H__B2B58F3E_46DD_44C9_80DE_5A96801FB719__INCLUDED_)
#define AFX_ANALYZERCTRL_H__B2B58F3E_46DD_44C9_80DE_5A96801FB719__INCLUDED_
//#ifdef ANALYZERCTRL_DLL
extern "C" __declspec(dllexport) BOOL OpenAnalyzer(char * DevName, int DevNo);
extern "C" __declspec(dllexport) void CloseAnalyzer(int DevNo);
extern "C" __declspec(dllexport) BOOL SetAnalyzer(float fFreq, int iSpan, int iAmptdYS,
					 float fMark, int iBandSpan, int iAveNum);
extern "C" __declspec(dllexport) double GetBandPower();
extern "C" __declspec(dllexport) double GetBandWidth();
extern "C" __declspec(dllexport) BOOL IsOpened();
extern "C" __declspec(dllexport) void ExecOrder_ANA(CString aOrder);
//
//#else
//extern  __declspec(dllimport) BOOL OpenAnalyzer(char * DevName, int DevNo);
//extern "C" __declspec(dllimport) void CloseAnalyzer(int DevNo);
//extern "C" __declspec(dllimport) BOOL SetAnalyzer(float fFreq=5.79f, int iSpan=10, int iAmptdYS=-10,
//					 float fMark=5.79f, int iBandSpan=2, int iAveNum=20);
//extern "C" __declspec(dllimport) double GetBandPower();
//extern "C" __declspec(dllimport) double GetBandWidth();
//extern __declspec(dllimport) BOOL IsOpened();
//#endif
#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

//#include <visa.h>
#include "visa.h"
//#include "Global.h"
//extern "C" BOOL _stdcall OpenAnalyzer(char * DevName, int DevNo);
//extern "C" void _stdcall CloseAnalyzer(int DevNo);
//extern "C" double _stdcall GetBandPower();
//extern "C" double _stdcall GetBandWidth();
//extern "C" BOOL _stdcall SetAnalyzer(float fFreq/* =5.79f */, int iSpan/* =10 */, int iAmptdYS/* =-10 */, 
//									 float fMark/* =5.79f */, int iBandSpan/* =2 */, int iAveNum/* =20 */);
//extern "C" BOOL _stdcall IsOpened();
class CAnalyzerCtrl
{

public:
	CAnalyzerCtrl();
	//virtual ~CAnalyzerCtrl();

public:
	BOOL OpenAnalyzer(char * DevName, int DevNo);
	void CloseAnalyzer(int DevNo);
	double GetBandPower();
	BOOL SetAnalyzer(float fFreq=5.79f, int iSpan=10, int iAmptdYS=-10,
					 float fMark=5.79f, int iBandSpan=2, int iAveNum=20);
	void GetBER(double *Power, unsigned long *Tbits, unsigned long *Ebits);
	double GetBandWidth();
	void GetMarkerVal(double * x,double * y);
	void GetIntervalVal(double * x,double * y);
    void ExecOrder_ANA(CString aOrder);
	void ExecOrder_SIG(CString aOrder);
	void ExecOrder_SIG1(CString aOrder);
	//BOOL IsOpened();//{return m_bOpened;}
private:
	ViSession m_VisDefaultRM_ANA;
	ViSession m_VisDefaultRM_SIG;
	ViSession m_VisDefaultRM_SIG1;
	ViSession m_Vis_ANA;	// 频谱仪
	ViSession m_Vis;
	ViSession m_Vis_SIG;	// 信号源
	ViSession m_Vis_SIG1;	// 信号源2号
	ViStatus m_ViStatus;
	BOOL m_bOpened;

};

#endif // !defined(AFX_ANALYZERCTRL_H__B2B58F3E_46DD_44C9_80DE_5A96801FB719__INCLUDED_)
