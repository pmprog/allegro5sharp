using System;
using System.Collections.Generic;
using System.Runtime;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace LitheNET.Allegro5
{

	public class Joystick
	{

		public const int AL_MAX_JOYSTICK_AXES = 3;
		public const int AL_MAX_JOYSTICK_STICKS = 16;
		public const int AL_MAX_JOYSTICK_BUTTONS = 32;

		public enum ALLEGRO_JOYFLAGS
		{
			ALLEGRO_JOYFLAG_DIGITAL = 0x01,
			ALLEGRO_JOYFLAG_ANALOGUE = 0x02
		};


		[StructLayout(LayoutKind.Sequential)]
		public unsafe struct ALLEGRO_JOYSTICK_STICK_STATE
		{
			public fixed float axis[AL_MAX_JOYSTICK_AXES];
		}

		[StructLayout(LayoutKind.Sequential)]
		public unsafe struct ALLEGRO_JOYSTICK_STATE
		{
			// [MarshalAs(UnmanagedType.ByValArray, SizeConst = AL_MAX_JOYSTICK_STICKS)] public ALLEGRO_JOYSTICK_STICK_STATE[] stick;
			/// <summary>
			/// Array Index = (Stick Index * AL_MAX_JOYSTICK_AXES) + Axis Index
			/// </summary>
			public fixed float sticks_axis[AL_MAX_JOYSTICK_STICKS * AL_MAX_JOYSTICK_AXES];
			public fixed int button[AL_MAX_JOYSTICK_BUTTONS];
		}


		[DllImport(Libraries.allegro_dll, CallingConvention = CallingConvention.Cdecl)] public static extern bool al_install_joystick();
		[DllImport(Libraries.allegro_dll, CallingConvention = CallingConvention.Cdecl)] public static extern bool al_uninstall_joystick();

		[DllImport(Libraries.allegro_dll, CallingConvention = CallingConvention.Cdecl)] public static extern bool al_reconfigure_joysticks();
		[DllImport(Libraries.allegro_dll, CallingConvention = CallingConvention.Cdecl)] public static extern int al_get_num_joysticks();
		[DllImport(Libraries.allegro_dll, CallingConvention = CallingConvention.Cdecl)] public static extern IntPtr al_get_joystick(int num);
		[DllImport(Libraries.allegro_dll, CallingConvention = CallingConvention.Cdecl)] public static extern void al_release_joystick(IntPtr joy);
		[DllImport(Libraries.allegro_dll, CallingConvention = CallingConvention.Cdecl)] public static extern bool al_get_joystick_active(IntPtr joy);
		[DllImport(Libraries.allegro_dll, CallingConvention = CallingConvention.Cdecl)] public static extern string al_get_joystick_name(IntPtr joy);
		[DllImport(Libraries.allegro_dll, CallingConvention = CallingConvention.Cdecl)] public static extern string al_get_joystick_stick_name(IntPtr joy, int stick);
		[DllImport(Libraries.allegro_dll, CallingConvention = CallingConvention.Cdecl)] public static extern string al_get_joystick_axis_name(IntPtr joy, int stick, int axis);
		[DllImport(Libraries.allegro_dll, CallingConvention = CallingConvention.Cdecl)] public static extern string al_get_joystick_button_name(IntPtr joy, int button);
		[DllImport(Libraries.allegro_dll, CallingConvention = CallingConvention.Cdecl)] public static extern int al_get_joystick_stick_flags(IntPtr joy, int stick);
		[DllImport(Libraries.allegro_dll, CallingConvention = CallingConvention.Cdecl)] public static extern int al_get_joystick_num_sticks(IntPtr joy);
		[DllImport(Libraries.allegro_dll, CallingConvention = CallingConvention.Cdecl)] public static extern int al_get_joystick_num_axes(IntPtr joy, int stick);
		[DllImport(Libraries.allegro_dll, CallingConvention = CallingConvention.Cdecl)] public static extern int al_get_joystick_num_buttons(IntPtr joy);
		[DllImport(Libraries.allegro_dll, CallingConvention = CallingConvention.Cdecl)] public static extern void al_get_joystick_state(IntPtr joy, ref ALLEGRO_JOYSTICK_STATE state);
		[DllImport(Libraries.allegro_dll, CallingConvention = CallingConvention.Cdecl)] public static extern IntPtr al_get_joystick_event_source();

	}

}
