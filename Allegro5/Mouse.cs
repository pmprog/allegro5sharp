using System;
using System.Collections.Generic;
using System.Runtime;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace LitheNET.Allegro5
{

	public class Mouse
	{

		public const int ALLEGRO_MOUSE_MAX_EXTRA_AXES = 4;

		public enum ALLEGRO_SYSTEM_MOUSE_CURSOR
		{
			ALLEGRO_SYSTEM_MOUSE_CURSOR_NONE = 0,
			ALLEGRO_SYSTEM_MOUSE_CURSOR_DEFAULT = 1,
			ALLEGRO_SYSTEM_MOUSE_CURSOR_ARROW = 2,
			ALLEGRO_SYSTEM_MOUSE_CURSOR_BUSY = 3,
			ALLEGRO_SYSTEM_MOUSE_CURSOR_QUESTION = 4,
			ALLEGRO_SYSTEM_MOUSE_CURSOR_EDIT = 5,
			ALLEGRO_SYSTEM_MOUSE_CURSOR_MOVE = 6,
			ALLEGRO_SYSTEM_MOUSE_CURSOR_RESIZE_N = 7,
			ALLEGRO_SYSTEM_MOUSE_CURSOR_RESIZE_W = 8,
			ALLEGRO_SYSTEM_MOUSE_CURSOR_RESIZE_S = 9,
			ALLEGRO_SYSTEM_MOUSE_CURSOR_RESIZE_E = 10,
			ALLEGRO_SYSTEM_MOUSE_CURSOR_RESIZE_NW = 11,
			ALLEGRO_SYSTEM_MOUSE_CURSOR_RESIZE_SW = 12,
			ALLEGRO_SYSTEM_MOUSE_CURSOR_RESIZE_SE = 13,
			ALLEGRO_SYSTEM_MOUSE_CURSOR_RESIZE_NE = 14,
			ALLEGRO_SYSTEM_MOUSE_CURSOR_PROGRESS = 15,
			ALLEGRO_SYSTEM_MOUSE_CURSOR_PRECISION = 16,
			ALLEGRO_SYSTEM_MOUSE_CURSOR_LINK = 17,
			ALLEGRO_SYSTEM_MOUSE_CURSOR_ALT_SELECT = 18,
			ALLEGRO_SYSTEM_MOUSE_CURSOR_UNAVAILABLE = 19,
			ALLEGRO_NUM_SYSTEM_MOUSE_CURSORS
		};

		[StructLayout(LayoutKind.Sequential)]
		public unsafe struct ALLEGRO_MOUSE_STATE
		{
			/* (x, y) Primary mouse position
			 * (z) Mouse wheel position (1D 'wheel'), or,
			 * (w, z) Mouse wheel position (2D 'ball')
			 * display - the display the mouse is on (coordinates are relative to this)
			 * pressure - the pressure applied to the mouse (for stylus/tablet)
			 */
			public int x;
			public int y;
			public int z;
			public int w;
			public fixed int more_axes[ALLEGRO_MOUSE_MAX_EXTRA_AXES];
			public int buttons;
			public float pressure;
			public IntPtr display;
		};


		[DllImport(Libraries.allegro_dll, CallingConvention = CallingConvention.Cdecl)] public static extern bool al_install_mouse();
		[DllImport(Libraries.allegro_dll, CallingConvention = CallingConvention.Cdecl)] public static extern bool al_uninstall_mouse();

		[DllImport(Libraries.allegro_dll, CallingConvention = CallingConvention.Cdecl)] public static extern uint al_get_mouse_num_axes();
		[DllImport(Libraries.allegro_dll, CallingConvention = CallingConvention.Cdecl)] public static extern uint al_get_mouse_num_buttons();
		[DllImport(Libraries.allegro_dll, CallingConvention = CallingConvention.Cdecl)] public static extern void al_get_mouse_state(ref ALLEGRO_MOUSE_STATE state);
		[DllImport(Libraries.allegro_dll, CallingConvention = CallingConvention.Cdecl)] public static extern int al_get_mouse_state_axis(ALLEGRO_MOUSE_STATE state, int axis);
		[DllImport(Libraries.allegro_dll, CallingConvention = CallingConvention.Cdecl)] public static extern bool al_mouse_button_down(ALLEGRO_MOUSE_STATE state, int button);
		[DllImport(Libraries.allegro_dll, CallingConvention = CallingConvention.Cdecl)] public static extern bool al_set_mouse_xy(IntPtr display, int x, int y);
		[DllImport(Libraries.allegro_dll, CallingConvention = CallingConvention.Cdecl)] public static extern bool al_set_mouse_z(int z);
		[DllImport(Libraries.allegro_dll, CallingConvention = CallingConvention.Cdecl)] public static extern bool al_set_mouse_w(int w);
		[DllImport(Libraries.allegro_dll, CallingConvention = CallingConvention.Cdecl)] public static extern bool al_set_mouse_axis(int which, int value);
		[DllImport(Libraries.allegro_dll, CallingConvention = CallingConvention.Cdecl)] public static extern IntPtr al_get_mouse_event_source();

		[DllImport(Libraries.allegro_dll, CallingConvention = CallingConvention.Cdecl)] public static extern IntPtr al_create_mouse_cursor(IntPtr bitmap, int x_focus, int y_focus);
		[DllImport(Libraries.allegro_dll, CallingConvention = CallingConvention.Cdecl)] public static extern void al_destroy_mouse_cursor(IntPtr cursor);
		[DllImport(Libraries.allegro_dll, CallingConvention = CallingConvention.Cdecl)] public static extern bool al_set_mouse_cursor(IntPtr display, IntPtr cursor);
		[DllImport(Libraries.allegro_dll, CallingConvention = CallingConvention.Cdecl)] public static extern bool al_set_system_mouse_cursor(IntPtr display, ALLEGRO_SYSTEM_MOUSE_CURSOR cursor_id);

		[DllImport(Libraries.allegro_dll, CallingConvention = CallingConvention.Cdecl)] public static extern bool al_get_mouse_cursor_position(ref int x, ref int y);
		[DllImport(Libraries.allegro_dll, CallingConvention = CallingConvention.Cdecl)] public static extern bool al_hide_mouse_cursor(IntPtr display);
		[DllImport(Libraries.allegro_dll, CallingConvention = CallingConvention.Cdecl)] public static extern bool al_show_mouse_cursor(IntPtr display);
		[DllImport(Libraries.allegro_dll, CallingConvention = CallingConvention.Cdecl)] public static extern bool al_grab_mouse(IntPtr display);
		[DllImport(Libraries.allegro_dll, CallingConvention = CallingConvention.Cdecl)] public static extern bool al_ungrab_mouse();

	}

}
