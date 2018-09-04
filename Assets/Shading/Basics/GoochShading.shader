Shader "Unlit/GoochShading"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
	}
	SubShader
	{
		Tags { "RenderType"="Opaque" }
		LOD 100

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"
			
            const float3 lightPos = float3(18,18,45);
            
			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
				float3 normal : NORMAL;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
				half3 worldNormal : TEXCOORD1;
				half3 worldPos : TEXCOORD2;
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;
			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				o.worldPos = mul (unity_ObjectToWorld, v.vertex);
				o.worldNormal = UnityObjectToWorldNormal(v.normal);
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
			    fixed4 colSurface = tex2D(_MainTex, i.uv);
			
				float3 colCool = float3 (0,0,0.55) + 0.25 * colSurface.xyz;
				float3 colWarm = float3 (0.3, 0.3, 0) + 0.25 * colSurface.xyz;
				
				float3 colHighlight = float3(0.9,0.9,0.9);
				
				float3 viewDirection = normalize(_WorldSpaceCameraPos - i.worldPos);
				float3 normalDirection = normalize(i.worldNormal);
				float3 lightDirection = normalize(lightPos - i.worldPos);
				
				float t = (dot(normalDirection, lightDirection) + 1) / 2;
				float3 r = 2 * (dot(normalDirection, lightDirection)) * normalDirection - lightDirection;
				float3 s = saturate((100 * dot(r,viewDirection) - 97));
				
				float3 colShaded = s * colHighlight + (1 - s) * (t * colWarm + (1 - t) * colCool);
				
				return float4(colShaded,1);
			}
			ENDCG
		}
	}
}
