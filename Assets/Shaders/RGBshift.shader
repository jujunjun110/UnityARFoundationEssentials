﻿Shader "Custom/RGBshift"
{
    Properties{
        _MainTex ("Texture", 2D) = "white" {}
        _Size ("Size", Range(0.0, 1.0)) = 0.025
    }
    SubShader
    {
        Cull Off
        ZTest Always
        ZWrite Off

        Tags { "RenderType"="Opaque" }

        Pass
        {
           CGPROGRAM
           #pragma vertex vert
           #pragma fragment frag
            
           #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            half _Size;
            
            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }
            
			float4 frag(v2f i) : SV_Target {
				half2 vUv = i.uv;
                // float angle = .0;
                // float amount = _Size;
				
				// half2 offset = amount * half2(cos(angle), sin(angle));
                half2 offset = half2(_Size, 0.0);
                // half2 offset = _Size;
				half4 cr = tex2D(_MainTex, vUv + offset);
				half4 cga = tex2D(_MainTex, vUv);
				half4 cb = tex2D(_MainTex, vUv - offset);
				return float4(cr.r, cga.g, cb.b, cga.a);
			}     

            // fixed4 frag (v2f i) : SV_Target
            // {
            //     // _Size = 0.01h;
            //     half4 col = tex2D(_MainTex, i.uv);

            //     half2 uvBase = i.uv - 0.5h;
            //     // R値を拡大したものに置き換える
            //     half2 uvR = uvBase * (1.0h - _Size * 2.0h) + 0.5h;
            //     col.r = tex2D(_MainTex, uvR).r;
            //     // G値を拡大したものに置き換える
            //     half2 uvG = uvBase * (1.0h - _Size) + 0.5h;
            //     col.g = tex2D(_MainTex, uvG).g;

            //     return col;
            // }


            ENDCG
        }
    }}
