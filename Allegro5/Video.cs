using System;
using System.Collections.Generic;
using System.Runtime;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace LitheNET.Allegro5
{

	public class Video
	{

		public enum ALLEGRO_VIDEO_POSITION
		{
			ALLEGRO_VIDEO_ACTUAL_POSITION = 0,
			ALLEGRO_VIDEO_VIDEO_DECODING_POSITION = 1,
			ALLEGRO_VIDEO_AUDIO_DECODING_POSITION = 2
		}

		[DllImport(Libraries.allegrovideo_dll, CallingConvention = CallingConvention.Cdecl)] public static extern IntPtr al_open_video(string filename);
		[DllImport(Libraries.allegrovideo_dll, CallingConvention = CallingConvention.Cdecl)] public static extern void al_close_video(IntPtr video);
		[DllImport(Libraries.allegrovideo_dll, CallingConvention = CallingConvention.Cdecl)] public static extern void al_start_video(IntPtr video, IntPtr mixer);
		[DllImport(Libraries.allegrovideo_dll, CallingConvention = CallingConvention.Cdecl)] public static extern void al_start_video_with_voice(IntPtr video, IntPtr voice);
		[DllImport(Libraries.allegrovideo_dll, CallingConvention = CallingConvention.Cdecl)] public static extern IntPtr al_get_video_event_source(IntPtr video);
		[DllImport(Libraries.allegrovideo_dll, CallingConvention = CallingConvention.Cdecl)] public static extern void al_pause_video(IntPtr video, bool paused);
		[DllImport(Libraries.allegrovideo_dll, CallingConvention = CallingConvention.Cdecl)] public static extern bool al_is_video_paused(IntPtr video);
		[DllImport(Libraries.allegrovideo_dll, CallingConvention = CallingConvention.Cdecl)] public static extern double al_get_video_aspect_ratio(IntPtr video);
		[DllImport(Libraries.allegrovideo_dll, CallingConvention = CallingConvention.Cdecl)] public static extern double al_get_video_audio_rate(IntPtr video);
		[DllImport(Libraries.allegrovideo_dll, CallingConvention = CallingConvention.Cdecl)] public static extern double al_get_video_fps(IntPtr video);
		[DllImport(Libraries.allegrovideo_dll, CallingConvention = CallingConvention.Cdecl)] public static extern int al_get_video_width(IntPtr video);
		[DllImport(Libraries.allegrovideo_dll, CallingConvention = CallingConvention.Cdecl)] public static extern int al_get_video_height(IntPtr video);
		[DllImport(Libraries.allegrovideo_dll, CallingConvention = CallingConvention.Cdecl)] public static extern IntPtr al_get_video_frame(IntPtr video);
		[DllImport(Libraries.allegrovideo_dll, CallingConvention = CallingConvention.Cdecl)] public static extern double al_get_video_position(IntPtr video, ALLEGRO_VIDEO_POSITION which);
		[DllImport(Libraries.allegrovideo_dll, CallingConvention = CallingConvention.Cdecl)] public static extern bool al_seek_video(IntPtr video, double pos_in_seconds);

	}

}
