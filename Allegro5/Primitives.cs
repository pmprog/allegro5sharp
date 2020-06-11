using System;
using System.Collections.Generic;
using System.Runtime;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace LitheNET.Allegro5
{

	public class Primitives
	{

		public enum ALLEGRO_LINE_JOIN
		{
			ALLEGRO_LINE_JOIN_NONE,
			ALLEGRO_LINE_JOIN_BEVEL,
			ALLEGRO_LINE_JOIN_ROUND,
			ALLEGRO_LINE_JOIN_MITER,
			ALLEGRO_LINE_JOIN_MITRE = ALLEGRO_LINE_JOIN_MITER
		};


		public enum ALLEGRO_LINE_CAP
		{
			ALLEGRO_LINE_CAP_NONE,
			ALLEGRO_LINE_CAP_SQUARE,
			ALLEGRO_LINE_CAP_ROUND,
			ALLEGRO_LINE_CAP_TRIANGLE,
			ALLEGRO_LINE_CAP_CLOSED
		};

		public enum ALLEGRO_PRIM_TYPE
		{
			ALLEGRO_PRIM_LINE_LIST,
			ALLEGRO_PRIM_LINE_STRIP,
			ALLEGRO_PRIM_LINE_LOOP,
			ALLEGRO_PRIM_TRIANGLE_LIST,
			ALLEGRO_PRIM_TRIANGLE_STRIP,
			ALLEGRO_PRIM_TRIANGLE_FAN,
			ALLEGRO_PRIM_POINT_LIST,
			ALLEGRO_PRIM_NUM_TYPES
		}

		public enum ALLEGRO_PRIM_ATTR
		{
			ALLEGRO_PRIM_POSITION = 1,
			ALLEGRO_PRIM_COLOR_ATTR,
			ALLEGRO_PRIM_TEX_COORD,
			ALLEGRO_PRIM_TEX_COORD_PIXEL,
			ALLEGRO_PRIM_USER_ATTR,
			//ALLEGRO_PRIM_ATTR_NUM = ALLEGRO_PRIM_USER_ATTR + ALLEGRO_PRIM_MAX_USER_ATTR
		};

		public enum ALLEGRO_PRIM_STORAGE
		{
			ALLEGRO_PRIM_FLOAT_2,
			ALLEGRO_PRIM_FLOAT_3,
			ALLEGRO_PRIM_SHORT_2,
			ALLEGRO_PRIM_FLOAT_1,
			ALLEGRO_PRIM_FLOAT_4,
			ALLEGRO_PRIM_UBYTE_4,
			ALLEGRO_PRIM_SHORT_4,
			ALLEGRO_PRIM_NORMALIZED_UBYTE_4,
			ALLEGRO_PRIM_NORMALIZED_SHORT_2,
			ALLEGRO_PRIM_NORMALIZED_SHORT_4,
			ALLEGRO_PRIM_NORMALIZED_USHORT_2,
			ALLEGRO_PRIM_NORMALIZED_USHORT_4,
			ALLEGRO_PRIM_HALF_FLOAT_2,
			ALLEGRO_PRIM_HALF_FLOAT_4
		};

		public enum ALLEGRO_PRIM_BUFFER_FLAGS
		{
			ALLEGRO_PRIM_BUFFER_STREAM = 0x01,
			ALLEGRO_PRIM_BUFFER_STATIC = 0x02,
			ALLEGRO_PRIM_BUFFER_DYNAMIC = 0x04,
			ALLEGRO_PRIM_BUFFER_READWRITE = 0x08
		};

		[StructLayout(LayoutKind.Sequential)]
		public struct ALLEGRO_VERTEX
		{
			public float x;
			public float y;
			public float z;
			public float u;
			public float v;
			public Color.ALLEGRO_COLOUR color;
		};

		[DllImport( Libraries.allegroprimitives_dll, CallingConvention = CallingConvention.Cdecl )] public static extern bool al_init_primitives_addon();
		[DllImport( Libraries.allegroprimitives_dll, CallingConvention = CallingConvention.Cdecl )] public static extern void al_shutdown_primitives_addon();


		[DllImport( Libraries.allegroprimitives_dll, CallingConvention = CallingConvention.Cdecl )] public static extern void al_draw_line(float x1, float y1, float x2, float y2, Color.ALLEGRO_COLOUR colour, float thickness);

		[DllImport( Libraries.allegroprimitives_dll, CallingConvention = CallingConvention.Cdecl )] public static extern void al_draw_triangle(float x1, float y1, float x2, float y2, float x3, float y3, Color.ALLEGRO_COLOUR colour, float thickness);
		[DllImport( Libraries.allegroprimitives_dll, CallingConvention = CallingConvention.Cdecl )] public static extern void al_draw_filled_triangle(float x1, float y1, float x2, float y2, float x3, float y3, Color.ALLEGRO_COLOUR colour);

		[DllImport( Libraries.allegroprimitives_dll, CallingConvention = CallingConvention.Cdecl )] public static extern void al_draw_rectangle(float x1, float y1, float x2, float y2, Color.ALLEGRO_COLOUR colour, float thickness);
		[DllImport( Libraries.allegroprimitives_dll, CallingConvention = CallingConvention.Cdecl )] public static extern void al_draw_filled_rectangle(float x1, float y1, float x2, float y2, Color.ALLEGRO_COLOUR colour);
		[DllImport( Libraries.allegroprimitives_dll, CallingConvention = CallingConvention.Cdecl )] public static extern void al_draw_rounded_rectangle(float x1, float y1, float x2, float y2, float rx, float ry, Color.ALLEGRO_COLOUR colour, float thickness);
		[DllImport( Libraries.allegroprimitives_dll, CallingConvention = CallingConvention.Cdecl )] public static extern void al_draw_filled_rounded_rectangle(float x1, float y1, float x2, float y2, float rx, float ry, Color.ALLEGRO_COLOUR colour);

		[DllImport( Libraries.allegroprimitives_dll, CallingConvention = CallingConvention.Cdecl )] public static extern void al_draw_pieslice(float cx, float cy, float r, float start_theta, float delta_theta, Color.ALLEGRO_COLOUR colour, float thickness);
		[DllImport( Libraries.allegroprimitives_dll, CallingConvention = CallingConvention.Cdecl )] public static extern void al_draw_filled_pieslice(float cx, float cy, float r, float start_theta, float delta_theta, Color.ALLEGRO_COLOUR colour);

		[DllImport( Libraries.allegroprimitives_dll, CallingConvention = CallingConvention.Cdecl )] public static extern void al_draw_ellipse(float cx, float cy, float rx, float ry, Color.ALLEGRO_COLOUR colour, float thickness);
		[DllImport( Libraries.allegroprimitives_dll, CallingConvention = CallingConvention.Cdecl )] public static extern void al_draw_filled_ellipse(float cx, float cy, float rx, float ry, Color.ALLEGRO_COLOUR colour);
		[DllImport( Libraries.allegroprimitives_dll, CallingConvention = CallingConvention.Cdecl )] public static extern void al_draw_circle(float cx, float cy, float r, Color.ALLEGRO_COLOUR colour, float thickness);
		[DllImport( Libraries.allegroprimitives_dll, CallingConvention = CallingConvention.Cdecl )] public static extern void al_draw_filled_circle(float cx, float cy, float r, Color.ALLEGRO_COLOUR colour);

		[DllImport( Libraries.allegroprimitives_dll, CallingConvention = CallingConvention.Cdecl )] public static extern void al_draw_arc(float cx, float cy, float r, float start_theta, float delta_theta, Color.ALLEGRO_COLOUR colour, float thickness);
		[DllImport( Libraries.allegroprimitives_dll, CallingConvention = CallingConvention.Cdecl )] public static extern void al_draw_elliptical_arc(float cx, float cy, float rx, float ry, float start_theta, float delta_theta, Color.ALLEGRO_COLOUR colour, float thickness);


		[DllImport( Libraries.allegroprimitives_dll, CallingConvention = CallingConvention.Cdecl )] public static extern void al_draw_polyline(float[] vertices, int vertex_stride, int vertex_count, ALLEGRO_LINE_JOIN join_style, ALLEGRO_LINE_CAP cap_style, Color.ALLEGRO_COLOUR colour, float thickness, float miter_limit);
		[DllImport( Libraries.allegroprimitives_dll, CallingConvention = CallingConvention.Cdecl )] public static extern void al_draw_polygon(IntPtr vertices, int vertex_count, ALLEGRO_LINE_JOIN join_style, Color.ALLEGRO_COLOUR colour, float thickness, float miter_limit);
		[DllImport( Libraries.allegroprimitives_dll, CallingConvention = CallingConvention.Cdecl )] public static extern void al_draw_filled_polygon(IntPtr vertices, int vertex_count, Color.ALLEGRO_COLOUR colour);
		[DllImport( Libraries.allegroprimitives_dll, CallingConvention = CallingConvention.Cdecl )] public static extern void al_draw_filled_polygon_with_holes(float[] vertices, int[] vertex_counts, Color.ALLEGRO_COLOUR colour);


		[DllImport(Libraries.allegroprimitives_dll, CallingConvention = CallingConvention.Cdecl)] public static extern int al_draw_prim(IntPtr vtxs, IntPtr decl, IntPtr texture, int start, int end, ALLEGRO_PRIM_TYPE type);
		[DllImport(Libraries.allegroprimitives_dll, CallingConvention = CallingConvention.Cdecl)] public static extern int al_draw_prim([MarshalAs(UnmanagedType.LPArray)] ALLEGRO_VERTEX[] vtxs, IntPtr decl, IntPtr texture, int start, int end, ALLEGRO_PRIM_TYPE type);


		public static void al_draw_polygon(float[] vertices, int vertex_count, ALLEGRO_LINE_JOIN join_style, Color.ALLEGRO_COLOUR colour, float thickness, float miter_limit)
		{
			IntPtr vptr = Marshal.AllocHGlobal(sizeof(float) * vertices.Count());
			Marshal.Copy(vertices, 0, vptr, vertices.Count());
			al_draw_polygon( vptr, vertex_count, join_style, colour, thickness, miter_limit );
			Marshal.FreeHGlobal(vptr);
		}

		public static void al_draw_filled_polygon(float[] vertices, int vertex_count, Color.ALLEGRO_COLOUR colour)
		{
			IntPtr vptr = Marshal.AllocHGlobal(sizeof(float) * vertices.Count());
			Marshal.Copy(vertices, 0, vptr, vertices.Count());
			al_draw_filled_polygon( vptr, vertex_count, colour );
			Marshal.FreeHGlobal(vptr);
		}

		/*
		public static int al_draw_prim(ALLEGRO_VERTEX[] vtxs, IntPtr decl, IntPtr texture, int start, int end, ALLEGRO_PRIM_TYPE type)
		{
			IntPtr vptr = Marshal.AllocHGlobal(sizeof(ALLEGRO_VERTEX) * vtxs.Count());
			Marshal.Copy(vtxs, 0, vptr, vtxs.Count());
			int r = al_draw_prim(vptr, decl, texture, start, end, type);
			Marshal.FreeHGlobal(vptr);
			return r;
		}
		*/
	}

}
