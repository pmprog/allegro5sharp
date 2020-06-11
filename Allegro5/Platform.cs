using System;
using System.Collections.Generic;
using System.Runtime;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace LitheNET.Allegro5
{
	public class Platform
	{
		public enum ALLEGRO_PLATFORM
		{
			Windows,
			Linux
		}


#if LINUX

		public static IntPtr al_get_win_window_handle(IntPtr display)
		{
			Return IntPtr.Zero;
		}

		public static ALLEGRO_PLATFORM al_get_platform()
		{
			return ALLEGRO_PLATFORM.Linux;
		}

#else

		[DllImport(Libraries.allegro_dll, CallingConvention = CallingConvention.Cdecl)] public static extern IntPtr al_get_win_window_handle(IntPtr display);

		public static ALLEGRO_PLATFORM al_get_platform()
		{
			return ALLEGRO_PLATFORM.Windows;
		}

#endif

	}
}
