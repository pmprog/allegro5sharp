using System;
using System.Collections.Generic;
using System.Runtime;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace LitheNET.Allegro5
{
	public class Monitor
	{

		[StructLayout(LayoutKind.Sequential)]
		public struct ALLEGRO_MONITOR_INFO
		{
			public int x1;
			public int y1;
			public int x2;
			public int y2;
		}

		[DllImport(Libraries.allegro_dll, CallingConvention = CallingConvention.Cdecl)] public static extern int al_get_new_display_adapter();
		[DllImport(Libraries.allegro_dll, CallingConvention = CallingConvention.Cdecl)] public static extern void al_set_new_display_adapter(int adapter);
		[DllImport(Libraries.allegro_dll, CallingConvention = CallingConvention.Cdecl)] public static extern bool al_get_monitor_info(int adapter, ref ALLEGRO_MONITOR_INFO info);
		[DllImport(Libraries.allegro_dll, CallingConvention = CallingConvention.Cdecl)] public static extern int al_get_num_video_adapters();

	}

}
