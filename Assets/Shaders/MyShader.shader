Shader "SamsungTest/MyShader" {
	Properties{
		_MainTex("Base (RGB)", 2D) = "white" {}
		_SecTex("Secondary (RGB)", 2D) = "white" {}
		_SecOpacity("Secondary opacity", Range(0,1)) = 0

		_Color("Color", Color) = (1,1,1,1)
		[NoScaleOffset] _BumpMap("Normalmap", 2D) = "bump" {}
	}
		SubShader{
		Tags{ "RenderType" = "Opaque" }
		LOD 200

		CGPROGRAM
#pragma surface surf Lambert noforwardadd

		sampler2D _MainTex;
	sampler2D _SecTex;
	sampler2D _BlendTex;
	float _SecOpacity;
	fixed4 _Color;
	sampler2D _BumpMap;

	struct Input {
		float2 uv_MainTex    : TEXCOORD0;
		float2 uv_SecTex    : TEXCOORD1;
	};

	void surf(Input IN, inout SurfaceOutput o) {
		//fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * (1 - _SecOpacity) + tex2D(_SecTex, IN.uv_SecTex) * _SecOpacity * _Color;
		fixed4 c = tex2D(_MainTex, IN.uv_MainTex) + (tex2D(_MainTex, IN.uv_MainTex) - ( 1 - tex2D(_SecTex, IN.uv_MainTex)) )* tex2D(_MainTex, IN.uv_MainTex)*_Color ;
		fixed4 ALPHA = tex2D(_SecTex, IN.uv_SecTex);
		o.Albedo = c.rgb;
		//o.Alpha = c.a;
		o.Alpha = ALPHA;
		o.Normal = UnpackNormal(tex2D(_BumpMap, IN.uv_MainTex));
	}
	ENDCG

	}

		FallBack "Diffuse"
}