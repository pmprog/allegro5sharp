using System;
using System.Collections.Generic;
using System.Runtime;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace LitheNET.Allegro5
{
	public class Timer
	{

		[DllImport(Libraries.allegro_dll, CallingConvention = CallingConvention.Cdecl)] public static extern IntPtr al_create_timer(double speed_secs);
		[DllImport(Libraries.allegro_dll, CallingConvention = CallingConvention.Cdecl)] public static extern void al_start_timer(IntPtr timer);
		[DllImport(Libraries.allegro_dll, CallingConvention = CallingConvention.Cdecl)] public static extern void al_stop_timer(IntPtr timer);
		[DllImport(Libraries.allegro_dll, CallingConvention = CallingConvention.Cdecl)] public static extern void al_destroy_timer(IntPtr timer);
		[DllImport(Libraries.allegro_dll, CallingConvention = CallingConvention.Cdecl)] public static extern IntPtr al_get_timer_event_source(IntPtr timer);

	}
}
