using System;
using System.Collections.Generic;
using System.Runtime;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace LitheNET.Allegro5
{
	public class Events
	{

		public enum ALLEGRO_EVENT_TYPE
		{
			ALLEGRO_EVENT_JOYSTICK_AXIS = 1,
			ALLEGRO_EVENT_JOYSTICK_BUTTON_DOWN = 2,
			ALLEGRO_EVENT_JOYSTICK_BUTTON_UP = 3,
			ALLEGRO_EVENT_JOYSTICK_CONFIGURATION = 4,

			ALLEGRO_EVENT_KEY_DOWN = 10,
			ALLEGRO_EVENT_KEY_CHAR = 11,
			ALLEGRO_EVENT_KEY_UP = 12,

			ALLEGRO_EVENT_MOUSE_AXES = 20,
			ALLEGRO_EVENT_MOUSE_BUTTON_DOWN = 21,
			ALLEGRO_EVENT_MOUSE_BUTTON_UP = 22,
			ALLEGRO_EVENT_MOUSE_ENTER_DISPLAY = 23,
			ALLEGRO_EVENT_MOUSE_LEAVE_DISPLAY = 24,
			ALLEGRO_EVENT_MOUSE_WARPED = 25,

			ALLEGRO_EVENT_TIMER = 30,

			ALLEGRO_EVENT_DISPLAY_EXPOSE = 40,
			ALLEGRO_EVENT_DISPLAY_RESIZE = 41,
			ALLEGRO_EVENT_DISPLAY_CLOSE = 42,
			ALLEGRO_EVENT_DISPLAY_LOST = 43,
			ALLEGRO_EVENT_DISPLAY_FOUND = 44,
			ALLEGRO_EVENT_DISPLAY_SWITCH_IN = 45,
			ALLEGRO_EVENT_DISPLAY_SWITCH_OUT = 46,
			ALLEGRO_EVENT_DISPLAY_ORIENTATION = 47,
			ALLEGRO_EVENT_DISPLAY_HALT_DRAWING = 48,
			ALLEGRO_EVENT_DISPLAY_RESUME_DRAWING = 49,

			ALLEGRO_EVENT_TOUCH_BEGIN = 50,
			ALLEGRO_EVENT_TOUCH_END = 51,
			ALLEGRO_EVENT_TOUCH_MOVE = 52,
			ALLEGRO_EVENT_TOUCH_CANCEL = 53,

			ALLEGRO_EVENT_DISPLAY_CONNECTED = 60,
			ALLEGRO_EVENT_DISPLAY_DISCONNECTED = 61,


			_KCM_STREAM_FEEDER_QUIT_EVENT_TYPE = 512,
			ALLEGRO_EVENT_AUDIO_STREAM_FRAGMENT = 513,
			ALLEGRO_EVENT_AUDIO_STREAM_FINISHED = 514,
			ALLEGRO_EVENT_AUDIO_RECORDER_FRAGMENT = 515,

		};

		[StructLayout(LayoutKind.Sequential)]
		public struct ALLEGRO_DISPLAY_EVENT
		{
			public ALLEGRO_EVENT_TYPE type;
			public IntPtr source;
			public double timestamp;
			public int x;
			public int y;
			public int width;
			public int height;
			public int orientation;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct ALLEGRO_JOYSTICK_EVENT
		{
			public ALLEGRO_EVENT_TYPE type;
			public IntPtr source;
			public double timestamp;
			public IntPtr id;
			public int stick;
			public int axis;
			public float pos;
			public int button;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct ALLEGRO_KEYBOARD_EVENT
		{
			public ALLEGRO_EVENT_TYPE type;
			public IntPtr source;
			public double timestamp;
			public IntPtr display;
			public int keycode;
			public int unichar;
			public uint modifiers;
			public bool repeat;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct ALLEGRO_MOUSE_EVENT
		{
			public ALLEGRO_EVENT_TYPE type;
			public IntPtr source;
			public double timestamp;
			public IntPtr display;
			public int x;
			public int y;
			public int z;
			public int w;
			public int dx;
			public int dy;
			public int dz;
			public int dw;
			public uint button;
			public float pressure;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct ALLEGRO_TIMER_EVENT
		{
			public ALLEGRO_EVENT_TYPE type;
			public IntPtr source;
			public double timestamp;
			public Int64 count;
			public double error;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct ALLEGRO_USER_EVENT
		{
			public ALLEGRO_EVENT_TYPE type;
			public IntPtr source;
			public double timestamp;
			public IntPtr data1;
			public IntPtr data2;
			public IntPtr data3;
			public IntPtr data4;
		}

		[StructLayout(LayoutKind.Explicit)]
		public struct ALLEGRO_EVENT
		{
			[FieldOffset(0)] public ALLEGRO_EVENT_TYPE type;
			[FieldOffset(0)] public ALLEGRO_DISPLAY_EVENT display;
			[FieldOffset(0)] public ALLEGRO_JOYSTICK_EVENT joystick;
			[FieldOffset(0)] public ALLEGRO_KEYBOARD_EVENT keyboard;
			[FieldOffset(0)] public ALLEGRO_MOUSE_EVENT mouse;
			[FieldOffset(0)] public ALLEGRO_TIMER_EVENT timer;
			[FieldOffset(0)] public ALLEGRO_USER_EVENT user;
		}

		[DllImport(Libraries.allegro_dll, CallingConvention = CallingConvention.Cdecl)] public static extern IntPtr al_create_event_queue();
		[DllImport(Libraries.allegro_dll, CallingConvention = CallingConvention.Cdecl)] public static extern void al_register_event_source(IntPtr queue, IntPtr source);
		[DllImport(Libraries.allegro_dll, CallingConvention = CallingConvention.Cdecl)] public static extern void al_unregister_event_source(IntPtr queue, IntPtr source);
		[DllImport(Libraries.allegro_dll, CallingConvention = CallingConvention.Cdecl)] public static extern void al_destroy_event_queue(IntPtr queue);
		[DllImport(Libraries.allegro_dll, CallingConvention = CallingConvention.Cdecl)] public static extern bool al_is_event_queue_empty(IntPtr queue);
		[DllImport(Libraries.allegro_dll, CallingConvention = CallingConvention.Cdecl)] public static extern bool al_get_next_event(IntPtr queue, ref ALLEGRO_EVENT allegroevent);

	}
}
