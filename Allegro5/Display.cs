using System;
using System.Collections.Generic;
using System.Runtime;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace LitheNET.Allegro5
{
	public class Display
	{

		public enum ALLEGRO_DISPLAY_FLAGS
		{
			ALLEGRO_WINDOWED = 1 << 0,
			ALLEGRO_FULLSCREEN = 1 << 1,
			ALLEGRO_OPENGL = 1 << 2,
			ALLEGRO_DIRECT3D_INTERNAL = 1 << 3,
			ALLEGRO_RESIZABLE = 1 << 4,
			ALLEGRO_FRAMELESS = 1 << 5,
			ALLEGRO_NOFRAME = ALLEGRO_FRAMELESS, /* older synonym */
			ALLEGRO_GENERATE_EXPOSE_EVENTS = 1 << 6,
			ALLEGRO_OPENGL_3_0 = 1 << 7,
			ALLEGRO_OPENGL_FORWARD_COMPATIBLE = 1 << 8,
			ALLEGRO_FULLSCREEN_WINDOW = 1 << 9,
			ALLEGRO_MINIMIZED = 1 << 10,
			ALLEGRO_PROGRAMMABLE_PIPELINE = 1 << 11,
			ALLEGRO_GTK_TOPLEVEL_INTERNAL = 1 << 12,
			ALLEGRO_MAXIMIZED = 1 << 13,
			ALLEGRO_OPENGL_ES_PROFILE = 1 << 14,
		};

		public enum ALLEGRO_DISPLAY_ORIENTATION
		{
			ALLEGRO_DISPLAY_ORIENTATION_UNKNOWN = 0,
			ALLEGRO_DISPLAY_ORIENTATION_0_DEGREES = 1,
			ALLEGRO_DISPLAY_ORIENTATION_90_DEGREES = 2,
			ALLEGRO_DISPLAY_ORIENTATION_180_DEGREES = 4,
			ALLEGRO_DISPLAY_ORIENTATION_270_DEGREES = 8,
			ALLEGRO_DISPLAY_ORIENTATION_PORTRAIT = 5,
			ALLEGRO_DISPLAY_ORIENTATION_LANDSCAPE = 10,
			ALLEGRO_DISPLAY_ORIENTATION_ALL = 15,
			ALLEGRO_DISPLAY_ORIENTATION_FACE_UP = 16,
			ALLEGRO_DISPLAY_ORIENTATION_FACE_DOWN = 32
		};

		public enum ALLEGRO_DISPLAY_OPTIONS
		{
			ALLEGRO_RED_SIZE = 0,
			ALLEGRO_GREEN_SIZE = 1,
			ALLEGRO_BLUE_SIZE = 2,
			ALLEGRO_ALPHA_SIZE = 3,
			ALLEGRO_RED_SHIFT = 4,
			ALLEGRO_GREEN_SHIFT = 5,
			ALLEGRO_BLUE_SHIFT = 6,
			ALLEGRO_ALPHA_SHIFT = 7,
			ALLEGRO_ACC_RED_SIZE = 8,
			ALLEGRO_ACC_GREEN_SIZE = 9,
			ALLEGRO_ACC_BLUE_SIZE = 10,
			ALLEGRO_ACC_ALPHA_SIZE = 11,
			ALLEGRO_STEREO = 12,
			ALLEGRO_AUX_BUFFERS = 13,
			ALLEGRO_COLOR_SIZE = 14,
			ALLEGRO_DEPTH_SIZE = 15,
			ALLEGRO_STENCIL_SIZE = 16,
			ALLEGRO_SAMPLE_BUFFERS = 17,
			ALLEGRO_SAMPLES = 18,
			ALLEGRO_RENDER_METHOD = 19,
			ALLEGRO_FLOAT_COLOR = 20,
			ALLEGRO_FLOAT_DEPTH = 21,
			ALLEGRO_SINGLE_BUFFER = 22,
			ALLEGRO_SWAP_METHOD = 23,
			ALLEGRO_COMPATIBLE_DISPLAY = 24,
			ALLEGRO_UPDATE_DISPLAY_REGION = 25,
			ALLEGRO_VSYNC = 26,
			ALLEGRO_MAX_BITMAP_SIZE = 27,
			ALLEGRO_SUPPORT_NPOT_BITMAP = 28,
			ALLEGRO_CAN_DRAW_INTO_BITMAP = 29,
			ALLEGRO_SUPPORT_SEPARATE_ALPHA = 30,
			ALLEGRO_AUTO_CONVERT_BITMAPS = 31,
			ALLEGRO_SUPPORTED_ORIENTATIONS = 32,
			ALLEGRO_OPENGL_MAJOR_VERSION = 33,
			ALLEGRO_OPENGL_MINOR_VERSION = 34,
			ALLEGRO_DISPLAY_OPTIONS_COUNT
		};

		[DllImport(Libraries.allegro_dll, CallingConvention = CallingConvention.Cdecl)] public static extern IntPtr al_create_display(int width, int height);
		[DllImport(Libraries.allegro_dll, CallingConvention = CallingConvention.Cdecl)] public static extern IntPtr al_get_display_event_source(IntPtr display);
		[DllImport(Libraries.allegro_dll, CallingConvention = CallingConvention.Cdecl)] public static extern void al_destroy_display(IntPtr display);

		[DllImport(Libraries.allegro_dll, CallingConvention = CallingConvention.Cdecl)] public static extern void al_set_window_title(IntPtr display, string title);
		[DllImport(Libraries.allegro_dll, CallingConvention = CallingConvention.Cdecl)] public static extern void al_set_display_icon(IntPtr display, IntPtr bitmap);

		[DllImport(Libraries.allegro_dll, CallingConvention = CallingConvention.Cdecl)] public static extern ALLEGRO_DISPLAY_FLAGS al_get_new_display_flags();
		[DllImport(Libraries.allegro_dll, CallingConvention = CallingConvention.Cdecl)] public static extern void al_set_new_display_flags(ALLEGRO_DISPLAY_FLAGS flags);
		[DllImport(Libraries.allegro_dll, CallingConvention = CallingConvention.Cdecl)] public static extern int al_get_display_option(IntPtr display, ALLEGRO_DISPLAY_OPTIONS option);

		[DllImport(Libraries.allegro_dll, CallingConvention = CallingConvention.Cdecl)] public static extern int al_get_new_window_position(ref int x, ref int y);
		[DllImport(Libraries.allegro_dll, CallingConvention = CallingConvention.Cdecl)] public static extern int al_set_new_window_position(int x, int y);

		[DllImport(Libraries.allegro_dll, CallingConvention = CallingConvention.Cdecl)] public static extern IntPtr al_get_backbuffer(IntPtr display);
		[DllImport(Libraries.allegro_dll, CallingConvention = CallingConvention.Cdecl)] public static extern IntPtr al_get_target_bitmap();
		[DllImport(Libraries.allegro_dll, CallingConvention = CallingConvention.Cdecl)] public static extern void al_flip_display();
		[DllImport(Libraries.allegro_dll, CallingConvention = CallingConvention.Cdecl)] public static extern bool al_wait_for_vsync();


		[DllImport(Libraries.allegro_dll, CallingConvention = CallingConvention.Cdecl)] public static extern int al_get_display_width(IntPtr display);
		[DllImport(Libraries.allegro_dll, CallingConvention = CallingConvention.Cdecl)] public static extern int al_get_display_height(IntPtr display);
		[DllImport(Libraries.allegro_dll, CallingConvention = CallingConvention.Cdecl)] public static extern bool al_resize_display(IntPtr display, int width, int height);
		[DllImport(Libraries.allegro_dll, CallingConvention = CallingConvention.Cdecl)] public static extern bool al_acknowledge_resize(IntPtr display);
		[DllImport(Libraries.allegro_dll, CallingConvention = CallingConvention.Cdecl)] public static extern void al_get_window_position(IntPtr display, ref int x, ref int y);
		[DllImport(Libraries.allegro_dll, CallingConvention = CallingConvention.Cdecl)] public static extern void al_set_window_position(IntPtr display, int x, int y);
		[DllImport(Libraries.allegro_dll, CallingConvention = CallingConvention.Cdecl)] public static extern ALLEGRO_DISPLAY_FLAGS al_get_display_flags(IntPtr display);
		[DllImport(Libraries.allegro_dll, CallingConvention = CallingConvention.Cdecl)] public static extern bool al_set_display_flag(IntPtr display, ALLEGRO_DISPLAY_FLAGS flag, bool onoff);

		[DllImport(Libraries.allegro_dll, CallingConvention = CallingConvention.Cdecl)] public static extern Graphics.ALLEGRO_PIXEL_FORMAT al_get_display_format(IntPtr display);
		[DllImport(Libraries.allegro_dll, CallingConvention = CallingConvention.Cdecl)] public static extern ALLEGRO_DISPLAY_ORIENTATION al_get_display_orientation(IntPtr display);

	}
}
