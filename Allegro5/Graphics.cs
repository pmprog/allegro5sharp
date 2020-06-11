using System;
using System.Collections.Generic;
using System.Runtime;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace LitheNET.Allegro5
{

	public class Graphics
	{

		public enum ALLEGRO_PIXEL_FORMAT
		{
			ALLEGRO_PIXEL_FORMAT_ANY = 0,
			ALLEGRO_PIXEL_FORMAT_ANY_NO_ALPHA = 1,
			ALLEGRO_PIXEL_FORMAT_ANY_WITH_ALPHA = 2,
			ALLEGRO_PIXEL_FORMAT_ANY_15_NO_ALPHA = 3,
			ALLEGRO_PIXEL_FORMAT_ANY_16_NO_ALPHA = 4,
			ALLEGRO_PIXEL_FORMAT_ANY_16_WITH_ALPHA = 5,
			ALLEGRO_PIXEL_FORMAT_ANY_24_NO_ALPHA = 6,
			ALLEGRO_PIXEL_FORMAT_ANY_32_NO_ALPHA = 7,
			ALLEGRO_PIXEL_FORMAT_ANY_32_WITH_ALPHA = 8,
			ALLEGRO_PIXEL_FORMAT_ARGB_8888 = 9,
			ALLEGRO_PIXEL_FORMAT_RGBA_8888 = 10,
			ALLEGRO_PIXEL_FORMAT_ARGB_4444 = 11,
			ALLEGRO_PIXEL_FORMAT_RGB_888 = 12, /* 24 bit format */
			ALLEGRO_PIXEL_FORMAT_RGB_565 = 13,
			ALLEGRO_PIXEL_FORMAT_RGB_555 = 14,
			ALLEGRO_PIXEL_FORMAT_RGBA_5551 = 15,
			ALLEGRO_PIXEL_FORMAT_ARGB_1555 = 16,
			ALLEGRO_PIXEL_FORMAT_ABGR_8888 = 17,
			ALLEGRO_PIXEL_FORMAT_XBGR_8888 = 18,
			ALLEGRO_PIXEL_FORMAT_BGR_888 = 19, /* 24 bit format */
			ALLEGRO_PIXEL_FORMAT_BGR_565 = 20,
			ALLEGRO_PIXEL_FORMAT_BGR_555 = 21,
			ALLEGRO_PIXEL_FORMAT_RGBX_8888 = 22,
			ALLEGRO_PIXEL_FORMAT_XRGB_8888 = 23,
			ALLEGRO_PIXEL_FORMAT_ABGR_F32 = 24,
			ALLEGRO_PIXEL_FORMAT_ABGR_8888_LE = 25,
			ALLEGRO_PIXEL_FORMAT_RGBA_4444 = 26,
			ALLEGRO_PIXEL_FORMAT_SINGLE_CHANNEL_8 = 27,
			ALLEGRO_PIXEL_FORMAT_COMPRESSED_RGBA_DXT1 = 28,
			ALLEGRO_PIXEL_FORMAT_COMPRESSED_RGBA_DXT3 = 29,
			ALLEGRO_PIXEL_FORMAT_COMPRESSED_RGBA_DXT5 = 30,
			ALLEGRO_NUM_PIXEL_FORMATS
		};

		public enum ALLEGRO_LOCK_FLAGS
		{
			ALLEGRO_LOCK_EMPTY = 0,
			ALLEGRO_LOCK_READWRITE = 0,
			ALLEGRO_LOCK_READONLY = 1,
			ALLEGRO_LOCK_WRITEONLY = 2
		};

		public enum ALLEGRO_BITMAP_FLAGS
		{
			NONE = 0,
			ALLEGRO_MEMORY_BITMAP = 0x0001,
			_ALLEGRO_KEEP_BITMAP_FORMAT = 0x0002, /* now a bitmap loader flag */
			ALLEGRO_FORCE_LOCKING = 0x0004, /* no longer honoured */
			ALLEGRO_NO_PRESERVE_TEXTURE = 0x0008,
			_ALLEGRO_ALPHA_TEST = 0x0010,   /* now a render state flag */
			_ALLEGRO_INTERNAL_OPENGL = 0x0020,
			ALLEGRO_MIN_LINEAR = 0x0040,
			ALLEGRO_MAG_LINEAR = 0x0080,
			ALLEGRO_MIPMAP = 0x0100,
			_ALLEGRO_NO_PREMULTIPLIED_ALPHA = 0x0200, /* now a bitmap loader flag */
			ALLEGRO_VIDEO_BITMAP = 0x0400,
			ALLEGRO_CONVERT_BITMAP = 0x1000
		};

		public enum ALLEGRO_BLIT_FLAGS
		{
			NONE = 0,
			ALLEGRO_FLIP_HORIZONTAL = 0x00001,
			ALLEGRO_FLIP_VERTICAL = 0x00002
		};

		public enum ALLEGRO_BLEND_MODE
		{
			ALLEGRO_ZERO = 0,
			ALLEGRO_ONE = 1,
			ALLEGRO_ALPHA = 2,
			ALLEGRO_INVERSE_ALPHA = 3,
			ALLEGRO_SRC_COLOR = 4,
			ALLEGRO_DEST_COLOR = 5,
			ALLEGRO_INVERSE_SRC_COLOR = 6,
			ALLEGRO_INVERSE_DEST_COLOR = 7,
			ALLEGRO_CONST_COLOR = 8,
			ALLEGRO_INVERSE_CONST_COLOR = 9,
			ALLEGRO_NUM_BLEND_MODES
		};

		public enum ALLEGRO_BLEND_OPERATIONS
		{
			ALLEGRO_ADD = 0,
			ALLEGRO_SRC_MINUS_DEST = 1,
			ALLEGRO_DEST_MINUS_SRC = 2,
			ALLEGRO_NUM_BLEND_OPERATIONS
		};

		[StructLayout(LayoutKind.Sequential)]
		public struct ALLEGRO_LOCKED_REGION
		{
			public IntPtr data;
			public int format;
			public int pitch;
			public int pixel_size;
		}

		[DllImport(Libraries.allegro_dll, CallingConvention = CallingConvention.Cdecl)] public static extern IntPtr al_lock_bitmap(IntPtr bitmap, ALLEGRO_PIXEL_FORMAT format, ALLEGRO_LOCK_FLAGS flags);
		[DllImport(Libraries.allegro_dll, CallingConvention = CallingConvention.Cdecl)] public static extern IntPtr al_lock_bitmap_region(IntPtr bitmap, int x, int y, int w, int h, ALLEGRO_PIXEL_FORMAT format, ALLEGRO_LOCK_FLAGS flags);
		[DllImport(Libraries.allegro_dll, CallingConvention = CallingConvention.Cdecl)] public static extern void al_unlock_bitmap(IntPtr bitmap);
		[DllImport(Libraries.allegro_dll, CallingConvention = CallingConvention.Cdecl)] public static extern bool al_is_bitmap_locked(IntPtr bitmap);

		[DllImport(Libraries.allegro_dll, CallingConvention = CallingConvention.Cdecl)] public static extern IntPtr al_create_bitmap(int w, int h);
		[DllImport(Libraries.allegro_dll, CallingConvention = CallingConvention.Cdecl)] public static extern void al_convert_bitmap(IntPtr bitmap);
		[DllImport(Libraries.allegro_dll, CallingConvention = CallingConvention.Cdecl)] public static extern void al_destroy_bitmap(IntPtr bitmap);

		[DllImport(Libraries.allegro_dll, CallingConvention = CallingConvention.Cdecl)] public static extern ALLEGRO_BITMAP_FLAGS al_get_new_bitmap_flags();
		[DllImport(Libraries.allegro_dll, CallingConvention = CallingConvention.Cdecl)] public static extern ALLEGRO_PIXEL_FORMAT al_get_new_bitmap_format();
		[DllImport(Libraries.allegro_dll, CallingConvention = CallingConvention.Cdecl)] public static extern void al_set_new_bitmap_flags(ALLEGRO_BITMAP_FLAGS flags);
		[DllImport(Libraries.allegro_dll, CallingConvention = CallingConvention.Cdecl)] public static extern void al_set_new_bitmap_format(ALLEGRO_PIXEL_FORMAT format);

		[DllImport(Libraries.allegro_dll, CallingConvention = CallingConvention.Cdecl)] public static extern ALLEGRO_BITMAP_FLAGS al_get_bitmap_flags(IntPtr bitmap);
		[DllImport(Libraries.allegro_dll, CallingConvention = CallingConvention.Cdecl)] public static extern ALLEGRO_PIXEL_FORMAT al_get_bitmap_format(IntPtr bitmap);
		[DllImport(Libraries.allegro_dll, CallingConvention = CallingConvention.Cdecl)] public static extern int al_get_bitmap_width(IntPtr bitmap);
		[DllImport(Libraries.allegro_dll, CallingConvention = CallingConvention.Cdecl)] public static extern int al_get_bitmap_height(IntPtr bitmap);


		[DllImport(Libraries.allegro_dll, CallingConvention = CallingConvention.Cdecl)] public static extern void al_clear_to_color(Color.ALLEGRO_COLOUR colour);
		[DllImport(Libraries.allegro_dll, CallingConvention = CallingConvention.Cdecl)] public static extern void al_draw_bitmap(IntPtr bitmap, float x, float y, ALLEGRO_BLIT_FLAGS flags);
		[DllImport(Libraries.allegro_dll, CallingConvention = CallingConvention.Cdecl)] public static extern void al_draw_tinted_bitmap(IntPtr bitmap, Color.ALLEGRO_COLOUR tint, float x, float y, ALLEGRO_BLIT_FLAGS flags);
		[DllImport(Libraries.allegro_dll, CallingConvention = CallingConvention.Cdecl)] public static extern void al_draw_bitmap_region(IntPtr bitmap, float sx, float sy, float sw, float sh, float dx, float dy, ALLEGRO_BLIT_FLAGS flags);
		[DllImport(Libraries.allegro_dll, CallingConvention = CallingConvention.Cdecl)] public static extern void al_draw_tinted_bitmap_region(IntPtr bitmap, Color.ALLEGRO_COLOUR tint, float sx, float sy, float sw, float sh, float dx, float dy, ALLEGRO_BLIT_FLAGS flags);
		[DllImport(Libraries.allegro_dll, CallingConvention = CallingConvention.Cdecl)] public static extern void al_draw_rotated_bitmap(IntPtr bitmap, float cx, float cy, float dx, float dy, float angle, ALLEGRO_BLIT_FLAGS flags);
		[DllImport(Libraries.allegro_dll, CallingConvention = CallingConvention.Cdecl)] public static extern void al_draw_tinted_rotated_bitmap(IntPtr bitmap, Color.ALLEGRO_COLOUR tint, float cx, float cy, float dx, float dy, float angle, ALLEGRO_BLIT_FLAGS flags);
		[DllImport(Libraries.allegro_dll, CallingConvention = CallingConvention.Cdecl)] public static extern void al_draw_scaled_rotated_bitmap(IntPtr bitmap, float cx, float cy, float dx, float dy, float xscale, float yscale, float angle, ALLEGRO_BLIT_FLAGS flags);
		[DllImport(Libraries.allegro_dll, CallingConvention = CallingConvention.Cdecl)] public static extern void al_draw_tinted_scaled_rotated_bitmap(IntPtr bitmap, Color.ALLEGRO_COLOUR tint, float cx, float cy, float dx, float dy, float xscale, float yscale, float angle, ALLEGRO_BLIT_FLAGS flags);
		[DllImport(Libraries.allegro_dll, CallingConvention = CallingConvention.Cdecl)] public static extern void al_draw_tinted_scaled_rotated_bitmap_region(IntPtr bitmap, float sx, float sy, float sw, float sh, Color.ALLEGRO_COLOUR tint, float cx, float cy, float dx, float dy, float xscale, float yscale, float angle, ALLEGRO_BLIT_FLAGS flags);
		[DllImport(Libraries.allegro_dll, CallingConvention = CallingConvention.Cdecl)] public static extern void al_draw_scaled_bitmap(IntPtr bitmap, float sx, float sy, float sw, float sh, float dx, float dy, float dw, float dh, ALLEGRO_BLIT_FLAGS flags);
		[DllImport(Libraries.allegro_dll, CallingConvention = CallingConvention.Cdecl)] public static extern void al_draw_tinted_scaled_bitmap(IntPtr bitmap, Color.ALLEGRO_COLOUR colour, float sx, float sy, float sw, float sh, float dx, float dy, float dw, float dh, ALLEGRO_BLIT_FLAGS flags);

		[DllImport(Libraries.allegro_dll, CallingConvention = CallingConvention.Cdecl)] public static extern IntPtr al_get_target_bitmap();
		[DllImport(Libraries.allegro_dll, CallingConvention = CallingConvention.Cdecl)] public static extern void al_set_target_bitmap(IntPtr bitmap);
		[DllImport(Libraries.allegro_dll, CallingConvention = CallingConvention.Cdecl)] public static extern void al_set_target_backbuffer(IntPtr display);
		[DllImport(Libraries.allegro_dll, CallingConvention = CallingConvention.Cdecl)] public static extern IntPtr al_get_current_display();

		[DllImport(Libraries.allegro_dll, CallingConvention = CallingConvention.Cdecl)] public static extern void al_get_blender(ref ALLEGRO_BLEND_OPERATIONS op, ref ALLEGRO_BLEND_MODE src, ref ALLEGRO_BLEND_MODE dst);
		[DllImport(Libraries.allegro_dll, CallingConvention = CallingConvention.Cdecl)] public static extern void al_set_blender(ALLEGRO_BLEND_OPERATIONS op, ALLEGRO_BLEND_MODE src, ALLEGRO_BLEND_MODE dst);

		[DllImport(Libraries.allegro_dll, CallingConvention = CallingConvention.Cdecl)] public static extern void al_hold_bitmap_drawing(bool hold);
		[DllImport(Libraries.allegro_dll, CallingConvention = CallingConvention.Cdecl)] public static extern void al_is_bitmap_drawing_held();

		[DllImport(Libraries.allegro_dll, CallingConvention = CallingConvention.Cdecl)] public static extern IntPtr al_load_bitmap(string filename);
		[DllImport(Libraries.allegro_dll, CallingConvention = CallingConvention.Cdecl)] public static extern bool al_save_bitmap(string filename, IntPtr bitmap);
	}

}
