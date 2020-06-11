using System;
using System.Collections.Generic;
using System.Runtime;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace LitheNET.Allegro5
{

	public class Audio
	{

		public const int ALLEGRO_MAX_CHANNELS = 8;

		public enum ALLEGRO_AUDIO_EVENT_TYPE
		{
			/* Internal, used to communicate with acodec. */
			/* Must be in 512 <= n < 1024 */
			_KCM_STREAM_FEEDER_QUIT_EVENT_TYPE = 512,
			ALLEGRO_EVENT_AUDIO_STREAM_FRAGMENT = 513,
			ALLEGRO_EVENT_AUDIO_STREAM_FINISHED = 514,
		};

		public enum ALLEGRO_AUDIO_DEPTH
		{
			/* Sample depth and type, and signedness. Mixers only use 32-bit signed
			 * float (-1..+1). The unsigned value is a bit-flag applied to the depth
			 * value.
			 */
			ALLEGRO_AUDIO_DEPTH_INT8 = 0x00,
			ALLEGRO_AUDIO_DEPTH_INT16 = 0x01,
			ALLEGRO_AUDIO_DEPTH_INT24 = 0x02,
			ALLEGRO_AUDIO_DEPTH_FLOAT32 = 0x03,

			ALLEGRO_AUDIO_DEPTH_UNSIGNED = 0x08,

			/* For convenience */
			ALLEGRO_AUDIO_DEPTH_UINT8 = ALLEGRO_AUDIO_DEPTH_INT8 | ALLEGRO_AUDIO_DEPTH_UNSIGNED,
			ALLEGRO_AUDIO_DEPTH_UINT16 = ALLEGRO_AUDIO_DEPTH_INT16 | ALLEGRO_AUDIO_DEPTH_UNSIGNED,
			ALLEGRO_AUDIO_DEPTH_UINT24 = ALLEGRO_AUDIO_DEPTH_INT24 | ALLEGRO_AUDIO_DEPTH_UNSIGNED
		};

		public enum ALLEGRO_CHANNEL_CONF
		{
			/* Speaker configuration (mono, stereo, 2.1, 3, etc). With regards to
			 * behavior, most of this code makes no distinction between, say, 4.1 and
			 * 5 speaker setups.. they both have 5 "channels". However, users would
			 * like the distinction, and later when the higher-level stuff is added,
			 * the differences will become more important. (v>>4)+(v&0xF) should yield
			 * the total channel count.
			 */
			ALLEGRO_CHANNEL_CONF_1 = 0x10,
			ALLEGRO_CHANNEL_CONF_2 = 0x20,
			ALLEGRO_CHANNEL_CONF_3 = 0x30,
			ALLEGRO_CHANNEL_CONF_4 = 0x40,
			ALLEGRO_CHANNEL_CONF_5_1 = 0x51,
			ALLEGRO_CHANNEL_CONF_6_1 = 0x61,
			ALLEGRO_CHANNEL_CONF_7_1 = 0x71

		};

		public enum ALLEGRO_PLAYMODE
		{
			ALLEGRO_PLAYMODE_ONCE = 0x100,
			ALLEGRO_PLAYMODE_LOOP = 0x101,
			ALLEGRO_PLAYMODE_BIDIR = 0x102,
			_ALLEGRO_PLAYMODE_STREAM_ONCE = 0x103,   /* internal */
			_ALLEGRO_PLAYMODE_STREAM_ONEDIR = 0x104    /* internal */
		};


		/* Enum: ALLEGRO_MIXER_QUALITY
		 */
		public enum ALLEGRO_MIXER_QUALITY
		{
			ALLEGRO_MIXER_QUALITY_POINT = 0x110,
			ALLEGRO_MIXER_QUALITY_LINEAR = 0x111,
			ALLEGRO_MIXER_QUALITY_CUBIC = 0x112
		};


		public struct ALLEGRO_SAMPLE_ID
		{
			public int _index;
			public int _id;
		};



		[DllImport(Libraries.allegroaudio_dll, CallingConvention = CallingConvention.Cdecl)] public static extern bool al_install_audio();
		[DllImport(Libraries.allegroaudio_dll, CallingConvention = CallingConvention.Cdecl)] public static extern void al_uninstall_audio();
		[DllImport(Libraries.allegroaudio_dll, CallingConvention = CallingConvention.Cdecl)] public static extern bool al_reserve_samples(int samples);


		[DllImport(Libraries.allegroaudio_dll, CallingConvention = CallingConvention.Cdecl)] public static extern IntPtr al_create_voice(uint frequency, ALLEGRO_AUDIO_DEPTH depth, ALLEGRO_CHANNEL_CONF conf);
		[DllImport(Libraries.allegroaudio_dll, CallingConvention = CallingConvention.Cdecl)] public static extern void al_destroy_voice(IntPtr voice);
		[DllImport(Libraries.allegroaudio_dll, CallingConvention = CallingConvention.Cdecl)] public static extern void al_detach_voice(IntPtr voice);
		[DllImport(Libraries.allegroaudio_dll, CallingConvention = CallingConvention.Cdecl)] public static extern bool al_attach_audio_stream_to_voice(IntPtr stream, IntPtr voice);
		[DllImport(Libraries.allegroaudio_dll, CallingConvention = CallingConvention.Cdecl)] public static extern bool al_attach_mixer_to_voice(IntPtr mixer, IntPtr voice);
		[DllImport(Libraries.allegroaudio_dll, CallingConvention = CallingConvention.Cdecl)] public static extern bool al_attach_sample_instance_to_voice(IntPtr sample, IntPtr voice);
		[DllImport(Libraries.allegroaudio_dll, CallingConvention = CallingConvention.Cdecl)] public static extern uint al_get_voice_frequency(IntPtr voice);
		[DllImport(Libraries.allegroaudio_dll, CallingConvention = CallingConvention.Cdecl)] public static extern ALLEGRO_CHANNEL_CONF al_get_voice_channels(IntPtr voice);
		[DllImport(Libraries.allegroaudio_dll, CallingConvention = CallingConvention.Cdecl)] public static extern ALLEGRO_AUDIO_DEPTH al_get_voice_depth(IntPtr voice);
		[DllImport(Libraries.allegroaudio_dll, CallingConvention = CallingConvention.Cdecl)] public static extern bool al_get_voice_playing(IntPtr voice);
		[DllImport(Libraries.allegroaudio_dll, CallingConvention = CallingConvention.Cdecl)] public static extern bool al_set_voice_playing(IntPtr voice, bool val);
		[DllImport(Libraries.allegroaudio_dll, CallingConvention = CallingConvention.Cdecl)] public static extern uint al_get_voice_position(IntPtr voice);
		[DllImport(Libraries.allegroaudio_dll, CallingConvention = CallingConvention.Cdecl)] public static extern bool al_set_voice_position(IntPtr voice, uint val);


		[DllImport(Libraries.allegroaudio_dll, CallingConvention = CallingConvention.Cdecl)] public static extern IntPtr al_create_sample(IntPtr buffer, uint samples, uint frequency, ALLEGRO_AUDIO_DEPTH depth, ALLEGRO_CHANNEL_CONF conf, bool free_buffer);
		[DllImport(Libraries.allegroaudio_dll, CallingConvention = CallingConvention.Cdecl)] public static extern void al_destroy_sample(IntPtr sample);
		[DllImport(Libraries.allegroaudio_dll, CallingConvention = CallingConvention.Cdecl)] public static extern bool al_play_sample(IntPtr sample, float gain, float pan, float speed, ALLEGRO_PLAYMODE loop, ref ALLEGRO_SAMPLE_ID id);
		[DllImport(Libraries.allegroaudio_dll, CallingConvention = CallingConvention.Cdecl)] public static extern void al_stop_sample(ref ALLEGRO_SAMPLE_ID id);
		[DllImport(Libraries.allegroaudio_dll, CallingConvention = CallingConvention.Cdecl)] public static extern void al_stop_samples();
		[DllImport(Libraries.allegroaudio_dll, CallingConvention = CallingConvention.Cdecl)] public static extern ALLEGRO_CHANNEL_CONF al_get_sample_channels(IntPtr sample);
		[DllImport(Libraries.allegroaudio_dll, CallingConvention = CallingConvention.Cdecl)] public static extern ALLEGRO_AUDIO_DEPTH al_get_sample_depth(IntPtr sample);
		[DllImport(Libraries.allegroaudio_dll, CallingConvention = CallingConvention.Cdecl)] public static extern uint al_get_sample_frequency(IntPtr sample);
		[DllImport(Libraries.allegroaudio_dll, CallingConvention = CallingConvention.Cdecl)] public static extern uint al_get_sample_length(IntPtr sample);
		[DllImport(Libraries.allegroaudio_dll, CallingConvention = CallingConvention.Cdecl)] public static extern IntPtr al_get_sample_data(IntPtr sample);
		

		[DllImport(Libraries.allegroaudio_dll, CallingConvention = CallingConvention.Cdecl)] public static extern IntPtr al_create_mixer(uint frequency, ALLEGRO_AUDIO_DEPTH depth, ALLEGRO_CHANNEL_CONF conf);
		[DllImport(Libraries.allegroaudio_dll, CallingConvention = CallingConvention.Cdecl)] public static extern void al_destroy_mixer(IntPtr mixer);
		[DllImport(Libraries.allegroaudio_dll, CallingConvention = CallingConvention.Cdecl)] public static extern IntPtr al_get_default_mixer();
		[DllImport(Libraries.allegroaudio_dll, CallingConvention = CallingConvention.Cdecl)] public static extern bool al_set_default_mixer(IntPtr mixer);
		[DllImport(Libraries.allegroaudio_dll, CallingConvention = CallingConvention.Cdecl)] public static extern bool al_restore_default_mixer();
		[DllImport(Libraries.allegroaudio_dll, CallingConvention = CallingConvention.Cdecl)] public static extern bool al_attach_mixer_to_mixer(IntPtr stream, IntPtr mixer);
		[DllImport(Libraries.allegroaudio_dll, CallingConvention = CallingConvention.Cdecl)] public static extern bool al_attach_audio_stream_to_mixer(IntPtr stream, IntPtr mixer);
		[DllImport(Libraries.allegroaudio_dll, CallingConvention = CallingConvention.Cdecl)] public static extern uint al_get_mixer_frequency(IntPtr mixer);
		[DllImport(Libraries.allegroaudio_dll, CallingConvention = CallingConvention.Cdecl)] public static extern uint al_set_mixer_frequency(IntPtr mixer, uint val);
		[DllImport(Libraries.allegroaudio_dll, CallingConvention = CallingConvention.Cdecl)] public static extern ALLEGRO_CHANNEL_CONF al_get_mixer_channels(IntPtr voice);
		[DllImport(Libraries.allegroaudio_dll, CallingConvention = CallingConvention.Cdecl)] public static extern ALLEGRO_AUDIO_DEPTH al_get_mixer_depth(IntPtr mixer);
		[DllImport(Libraries.allegroaudio_dll, CallingConvention = CallingConvention.Cdecl)] public static extern float al_get_mixer_gain(IntPtr mixer);
		[DllImport(Libraries.allegroaudio_dll, CallingConvention = CallingConvention.Cdecl)] public static extern bool al_set_mixer_gain(IntPtr mixer, float new_gain);
		[DllImport(Libraries.allegroaudio_dll, CallingConvention = CallingConvention.Cdecl)] public static extern ALLEGRO_MIXER_QUALITY al_get_mixer_quality(IntPtr mixer);
		[DllImport(Libraries.allegroaudio_dll, CallingConvention = CallingConvention.Cdecl)] public static extern bool al_set_mixer_quality(IntPtr mixer, ALLEGRO_MIXER_QUALITY new_quality);
		[DllImport(Libraries.allegroaudio_dll, CallingConvention = CallingConvention.Cdecl)] public static extern bool al_get_mixer_playing(IntPtr mixer);
		[DllImport(Libraries.allegroaudio_dll, CallingConvention = CallingConvention.Cdecl)] public static extern bool al_set_mixer_playing(IntPtr mixer, bool val);
		[DllImport(Libraries.allegroaudio_dll, CallingConvention = CallingConvention.Cdecl)] public static extern bool al_get_mixer_attached(IntPtr mixer);
		[DllImport(Libraries.allegroaudio_dll, CallingConvention = CallingConvention.Cdecl)] public static extern bool al_detach_mixer(IntPtr mixer);


		[DllImport(Libraries.allegroaudio_dll, CallingConvention = CallingConvention.Cdecl)] public static extern IntPtr al_create_audio_stream(uint fragment_count, uint frag_samples, uint frequency, ALLEGRO_AUDIO_DEPTH depth, ALLEGRO_CHANNEL_CONF conf);
		[DllImport(Libraries.allegroaudio_dll, CallingConvention = CallingConvention.Cdecl)] public static extern void al_destroy_audio_stream(IntPtr stream);
		[DllImport(Libraries.allegroaudio_dll, CallingConvention = CallingConvention.Cdecl)] public static extern IntPtr al_get_audio_stream_event_source(IntPtr stream);
		[DllImport(Libraries.allegroaudio_dll, CallingConvention = CallingConvention.Cdecl)] public static extern void al_drain_audio_stream(IntPtr stream);
		[DllImport(Libraries.allegroaudio_dll, CallingConvention = CallingConvention.Cdecl)] public static extern bool al_rewind_audio_stream(IntPtr stream);
		[DllImport(Libraries.allegroaudio_dll, CallingConvention = CallingConvention.Cdecl)] public static extern uint al_get_audio_stream_frequency(IntPtr stream);
		[DllImport(Libraries.allegroaudio_dll, CallingConvention = CallingConvention.Cdecl)] public static extern ALLEGRO_CHANNEL_CONF al_get_audio_stream_channels(IntPtr stream);
		[DllImport(Libraries.allegroaudio_dll, CallingConvention = CallingConvention.Cdecl)] public static extern ALLEGRO_AUDIO_DEPTH al_get_audio_stream_depth(IntPtr stream);
		[DllImport(Libraries.allegroaudio_dll, CallingConvention = CallingConvention.Cdecl)] public static extern uint al_get_audio_stream_length(IntPtr stream);
		[DllImport(Libraries.allegroaudio_dll, CallingConvention = CallingConvention.Cdecl)] public static extern float al_get_audio_stream_speed(IntPtr stream);
		[DllImport(Libraries.allegroaudio_dll, CallingConvention = CallingConvention.Cdecl)] public static extern bool al_set_audio_stream_speed(IntPtr stream, float val);
		[DllImport(Libraries.allegroaudio_dll, CallingConvention = CallingConvention.Cdecl)] public static extern float al_get_audio_stream_gain(IntPtr stream);
		[DllImport(Libraries.allegroaudio_dll, CallingConvention = CallingConvention.Cdecl)] public static extern bool al_set_audio_stream_gain(IntPtr stream, float val);
		[DllImport(Libraries.allegroaudio_dll, CallingConvention = CallingConvention.Cdecl)] public static extern float al_get_audio_stream_pan(IntPtr stream);
		[DllImport(Libraries.allegroaudio_dll, CallingConvention = CallingConvention.Cdecl)] public static extern bool al_set_audio_stream_pan(IntPtr stream, float val);
		[DllImport(Libraries.allegroaudio_dll, CallingConvention = CallingConvention.Cdecl)] public static extern bool al_get_audio_stream_playing(IntPtr stream);
		[DllImport(Libraries.allegroaudio_dll, CallingConvention = CallingConvention.Cdecl)] public static extern bool al_set_audio_stream_playing(IntPtr stream, bool val);
		[DllImport(Libraries.allegroaudio_dll, CallingConvention = CallingConvention.Cdecl)] public static extern ALLEGRO_PLAYMODE al_get_audio_stream_playmode(IntPtr stream);
		[DllImport(Libraries.allegroaudio_dll, CallingConvention = CallingConvention.Cdecl)] public static extern bool al_set_audio_stream_playmode(IntPtr stream, ALLEGRO_PLAYMODE val);
		[DllImport(Libraries.allegroaudio_dll, CallingConvention = CallingConvention.Cdecl)] public static extern bool al_get_audio_stream_attached(IntPtr stream);
		[DllImport(Libraries.allegroaudio_dll, CallingConvention = CallingConvention.Cdecl)] public static extern bool al_detach_audio_stream(IntPtr stream);
		[DllImport(Libraries.allegroaudio_dll, CallingConvention = CallingConvention.Cdecl)] public static extern bool al_seek_audio_stream_secs(IntPtr stream, double time);
		[DllImport(Libraries.allegroaudio_dll, CallingConvention = CallingConvention.Cdecl)] public static extern double al_get_audio_stream_position_secs(IntPtr stream);
		[DllImport(Libraries.allegroaudio_dll, CallingConvention = CallingConvention.Cdecl)] public static extern double al_get_audio_stream_length_secs(IntPtr stream);

		[DllImport(Libraries.allegroaudio_dll, CallingConvention = CallingConvention.Cdecl)] public static extern IntPtr al_load_sample(string filename);
		[DllImport(Libraries.allegroaudio_dll, CallingConvention = CallingConvention.Cdecl)] public static extern IntPtr al_load_audio_stream(string filename, uint buffer_count, uint samples);

		[DllImport(Libraries.allegroaudio_dll, CallingConvention = CallingConvention.Cdecl)] public static extern IntPtr al_get_audio_event_source(IntPtr stream);

		[DllImport(Libraries.allegroaudio_dll, CallingConvention = CallingConvention.Cdecl)] public static extern IntPtr al_create_audio_recorder(uint fragment_count, uint samples, uint frequency, ALLEGRO_AUDIO_DEPTH depth, ALLEGRO_CHANNEL_CONF conf);
		[DllImport(Libraries.allegroaudio_dll, CallingConvention = CallingConvention.Cdecl)] public static extern bool al_start_audio_recorder(IntPtr recorder);
		[DllImport(Libraries.allegroaudio_dll, CallingConvention = CallingConvention.Cdecl)] public static extern void al_stop_audio_recorder(IntPtr recorder);
		[DllImport(Libraries.allegroaudio_dll, CallingConvention = CallingConvention.Cdecl)] public static extern bool al_is_audio_recorder_recording(IntPtr recorder);
		[DllImport(Libraries.allegroaudio_dll, CallingConvention = CallingConvention.Cdecl)] public static extern IntPtr al_get_audio_recorder_event(IntPtr aevent);
		[DllImport(Libraries.allegroaudio_dll, CallingConvention = CallingConvention.Cdecl)] public static extern IntPtr al_get_audio_recorder_event_source(IntPtr recorder);
		[DllImport(Libraries.allegroaudio_dll, CallingConvention = CallingConvention.Cdecl)] public static extern void al_destroy_audio_recorder(IntPtr recorder);


	}

}
