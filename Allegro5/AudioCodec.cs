using System;
using System.Collections.Generic;
using System.Runtime;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace LitheNET.Allegro5
{

	public class AudioCodec
	{

		[DllImport(Libraries.allegroacodec_dll, CallingConvention = CallingConvention.Cdecl)] public static extern bool al_init_acodec_addon();

	}

}
