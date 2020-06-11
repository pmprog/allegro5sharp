using System;
using System.Collections.Generic;
using System.Runtime;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace LitheNET.Allegro5
{

	public class Color
	{

		[StructLayout(LayoutKind.Sequential)]
		public struct ALLEGRO_COLOUR
		{
			public float r;
			public float g;
			public float b;
			public float a;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct PackedARGB
		{
			public byte r;
			public byte g;
			public byte b;
			public byte a;
		};

		[DllImport(Libraries.allegro_dll, CallingConvention = CallingConvention.Cdecl)] public static extern ALLEGRO_COLOUR al_map_rgb(byte r, byte g, byte b);
		[DllImport(Libraries.allegro_dll, CallingConvention = CallingConvention.Cdecl)] public static extern ALLEGRO_COLOUR al_map_rgba(byte r, byte g, byte b, byte a);
		[DllImport(Libraries.allegro_dll, CallingConvention = CallingConvention.Cdecl)] public static extern ALLEGRO_COLOUR al_map_rgb_f(float r, float g, float b);
		[DllImport(Libraries.allegro_dll, CallingConvention = CallingConvention.Cdecl)] public static extern ALLEGRO_COLOUR al_map_rgba_f(float r, float g, float b, float a);

	}

}
