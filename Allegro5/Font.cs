using System;
using System.Collections.Generic;
using System.Runtime;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace LitheNET.Allegro5
{

	public class Font
	{

		public enum ALLEGRO_FONT_DRAW_FLAGS
		{
			ALLEGRO_NO_KERNING = -1,
			ALLEGRO_ALIGN_LEFT = 0,
			ALLEGRO_ALIGN_CENTRE = 1,
			ALLEGRO_ALIGN_CENTER = 1,
			ALLEGRO_ALIGN_RIGHT = 2,
			ALLEGRO_ALIGN_INTEGER = 4,
		};

		public enum ALLEGRO_FONT_TTF_LOAD_FLAGS
		{
			NONE = 0,
			ALLEGRO_TTF_NO_KERNING = 1,
			ALLEGRO_TTF_MONOCHROME = 2,
			ALLEGRO_TTF_NO_AUTOHINT = 4
		}


		[DllImport(Libraries.allegrofont_dll, CallingConvention = CallingConvention.Cdecl)] public static extern bool al_init_font_addon();
		[DllImport(Libraries.allegrofont_dll, CallingConvention = CallingConvention.Cdecl)] public static extern void al_shutdown_font_addon();

		[DllImport(Libraries.allegrofont_dll, CallingConvention = CallingConvention.Cdecl)] public static extern IntPtr al_load_font(string filename, int size, int flags);
		[DllImport(Libraries.allegrofont_dll, CallingConvention = CallingConvention.Cdecl)] public static extern void al_destroy_font(IntPtr font);
		[DllImport(Libraries.allegrofont_dll, CallingConvention = CallingConvention.Cdecl)] public static extern IntPtr al_create_builtin_font();

		[DllImport(Libraries.allegrofont_dll, CallingConvention = CallingConvention.Cdecl)] public static extern int al_get_font_line_height(IntPtr font);
		[DllImport(Libraries.allegrofont_dll, CallingConvention = CallingConvention.Cdecl)] public static extern int al_get_font_line_ascent(IntPtr font);
		[DllImport(Libraries.allegrofont_dll, CallingConvention = CallingConvention.Cdecl)] public static extern int al_get_font_line_descent(IntPtr font);
		[DllImport(Libraries.allegrofont_dll, CallingConvention = CallingConvention.Cdecl)] public static extern int al_get_text_width(IntPtr font, string str);
		[DllImport(Libraries.allegrofont_dll, CallingConvention = CallingConvention.Cdecl)] public static extern int al_get_font_text_width(IntPtr font, string str);

		[DllImport(Libraries.allegrofont_dll, CallingConvention = CallingConvention.Cdecl)] public static extern void al_draw_text(IntPtr font, Color.ALLEGRO_COLOUR colour, float x, float y, ALLEGRO_FONT_DRAW_FLAGS flags, string str);
		[DllImport(Libraries.allegrofont_dll, CallingConvention = CallingConvention.Cdecl)] public static extern void al_draw_justified_text(IntPtr font, Color.ALLEGRO_COLOUR colour, float x, float y, ALLEGRO_FONT_DRAW_FLAGS flags, string str);
		[DllImport(Libraries.allegrofont_dll, CallingConvention = CallingConvention.Cdecl)] public static extern void al_get_text_dimensions(IntPtr font, string str, ref int bbx, ref int bby, ref int bbw, ref int bbh);


		[DllImport(Libraries.allegrottf_dll, CallingConvention = CallingConvention.Cdecl)] public static extern bool al_init_ttf_addon();
		[DllImport(Libraries.allegrottf_dll, CallingConvention = CallingConvention.Cdecl)] public static extern void al_shutdown_ttf_addon();
		[DllImport(Libraries.allegrottf_dll, CallingConvention = CallingConvention.Cdecl)] public static extern IntPtr al_load_ttf_font(string filename, int size, ALLEGRO_FONT_TTF_LOAD_FLAGS flags);


	}

}
