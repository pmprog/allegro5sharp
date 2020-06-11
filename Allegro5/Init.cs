using System;
using System.Collections.Generic;
using System.Runtime;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace LitheNET.Allegro5
{
	public class Init
	{

		public const int ALLEGRO_VERSION = 5;
		public const int ALLEGRO_SUB_VERSION = 2;
		public const int ALLEGRO_WIP_VERSION = 4;
		public const int ALLEGRO_RELEASE_NUMBER = 1;
		public const int ALLEGRO_UNSTABLE_BIT = 0;

		[DllImport(Libraries.allegro_dll, CallingConvention = CallingConvention.Cdecl)] public static extern bool al_install_system(int version, IntPtr exitcb);
		[DllImport(Libraries.allegro_dll, CallingConvention = CallingConvention.Cdecl)] public static extern void al_uninstall_system();
		[DllImport(Libraries.allegro_dll, CallingConvention = CallingConvention.Cdecl)] public static extern bool al_inhibit_screensaver(bool inhibit);

		public static bool al_init()
		{
			int version = ((ALLEGRO_VERSION << 24) | (ALLEGRO_SUB_VERSION << 16) | (ALLEGRO_WIP_VERSION << 8) | ALLEGRO_RELEASE_NUMBER | ALLEGRO_UNSTABLE_BIT);
			return al_install_system(version, IntPtr.Zero);
		}

	}
}
