using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LitheNET.Allegro5
{
	public class Libraries
	{

#if LINUX

		public const string allegro_dll = "liballegro.so.5.2";
		public const string allegroaudio_dll = "liballegro_audio.so.5.2";
		public const string allegroacodec_dll = "liballegro_acodec.so.5.2";
		public const string allegrofont_dll = "liballegro_font.so.5.2";
		public const string allegroimage_dll = "liballegro_image.so.5.2";
		public const string allegrophysfs_dll = "liballegro_physfs.so.5.2";
		public const string allegroprimitives_dll = "liballegro_primitives.so.5.2";
		public const string allegrottf_dll = "liballegro_ttf.so.5.2";
		public const string allegrovideo_dll = "liballegro_video.so.5.2";

#else

		public const string allegro_dll = "allegro-5.2.dll";
		public const string allegroaudio_dll = "allegro_audio-5.2.dll";
		public const string allegroacodec_dll = "allegro_acodec-5.2.dll";
		public const string allegrofont_dll = "allegro_font-5.2.dll";
		public const string allegroimage_dll = "allegro_image-5.2.dll";
		public const string allegrophysfs_dll = "allegro_physfs-5.2.dll";
		public const string allegroprimitives_dll = "allegro_primitives-5.2.dll";
		public const string allegrottf_dll = "allegro_ttf-5.2.dll";
		public const string allegrovideo_dll = "allegro_video-5.2.dll";

#endif

	}
}
