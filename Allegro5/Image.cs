using System;
using System.Collections.Generic;
using System.Runtime;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace LitheNET.Allegro5
{
	public class Image
	{

		[DllImport(Libraries.allegroimage_dll, CallingConvention = CallingConvention.Cdecl)] public static extern bool al_init_image_addon();
		[DllImport(Libraries.allegroimage_dll, CallingConvention = CallingConvention.Cdecl)] public static extern bool al_shutdown_image_addon();

	}
}
