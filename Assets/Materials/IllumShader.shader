Shader "Unlit/451Shader"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
	}
	SubShader
	{
		Tags { "RenderType"="Opaque" }
		LOD 200
		Cull Off

		Pass
		{
			CGPROGRAM
			#pragma vertex MyVert
			#pragma fragment MyFrag
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float3 normal : NORMAL;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float4 vertex : SV_POSITION;
				float3 normal : NORMAL;
				float2 uv : TEXCOORD0;
				float3 vertexWC : TEXCOORD3;
			};

			sampler2D _MainTex;

			float4 LightPosition;

            // our own matrix
            float4x4 MyXformMat;  // our own transform matrix!!
            fixed4   MyColor;
			
			v2f MyVert (appdata v)
			{
				v2f o;
                
                // Can use one of the followings:
                // o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);  // Camera + GameObject transform TRS

                o.vertex = mul(MyXformMat, v.vertex);  // use our own transform matrix!
                    // MUST apply before camrea!
				o.uv = v.uv;

                o.vertex = mul(UNITY_MATRIX_VP, o.vertex);   // camera transform only

				o.vertexWC = mul(UNITY_MATRIX_M, v.vertex);

				float3 p = v.vertex + v.normal;	
				p = mul(UNITY_MATRIX_M, float4(p, 1));
				o.normal = normalize(p - o.vertexWC);		
                return o;
			}

			fixed4 ComputeDiffuse(v2f i)
			{
				float3 l = LightPosition;//normalize(LightPosition - i.vertexWC);
				return clamp(dot(i.normal, l), 0, 1);
			}
			
			fixed4 MyFrag (v2f i) : SV_Target
			{
				// sample the texture
                fixed4 col = MyColor;

				float diff = ComputeDiffuse(i);
				return col * diff;
			}
			ENDCG
		}
	}
}