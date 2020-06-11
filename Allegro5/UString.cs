using System;
using System.Collections.Generic;
using System.Runtime;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace LitheNET.Allegro5
{
	public class UString
	{

		[DllImport(Libraries.allegro_dll, CallingConvention = CallingConvention.Cdecl)] public static extern IntPtr al_ustr_new(string s);
		[DllImport(Libraries.allegro_dll, CallingConvention = CallingConvention.Cdecl)] public static extern void al_ustr_free(IntPtr us);
		[DllImport(Libraries.allegro_dll, CallingConvention = CallingConvention.Cdecl)] public static extern string al_cstr(IntPtr us);
		[DllImport(Libraries.allegro_dll, CallingConvention = CallingConvention.Cdecl)] public static extern uint al_ustr_append_chr(IntPtr us, int c);
		
	}
}
