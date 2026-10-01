using UnityEngine;

/*
 * Macchiato Core
 * Contact : crestudioplus@gmail.com // Twitter : https://twitter.com/VRC_Macchiato
 */

namespace Macchiato.Core {

	public static class ColorHelper {

		public struct Oklab {
			public float L, a, b;
		}

		public struct OklabGradient {
			public Color Base, Shadow1, Shadow2, Shadow3;
		}

		public static OklabGradient GetOklabGradient(Color TargetBaseColor, Color TargetShadow3Color) {
			Oklab BaseOklab = RGBToOklab(TargetBaseColor);
			Oklab Shadow3Oklab = RGBToOklab(TargetShadow3Color);
			return new OklabGradient {
				Base = TargetBaseColor,
				Shadow1 = OklabToRGB(InterpolateOklab(BaseOklab, Shadow3Oklab, 1f / 3f), Mathf.Lerp(TargetBaseColor.a, TargetShadow3Color.a, 1f / 3f)),
				Shadow2 = OklabToRGB(InterpolateOklab(BaseOklab, Shadow3Oklab, 2f / 3f), Mathf.Lerp(TargetBaseColor.a, TargetShadow3Color.a, 2f / 3f)),
				Shadow3 = TargetShadow3Color
			};
		}

		static Oklab InterpolateOklab(Oklab ColorA, Oklab ColorB, float Position) {
			return new Oklab {
				L = Mathf.Lerp(ColorA.L, ColorB.L, Position),
				a = Mathf.Lerp(ColorA.a, ColorB.a, Position),
				b = Mathf.Lerp(ColorA.b, ColorB.b, Position)
			};
		}

		static Oklab RGBToOklab(Color TargetColor) {
			Color LinearColor = TargetColor.linear;
			float R = LinearColor.r;
			float G = LinearColor.g;
			float B = LinearColor.b;
			float l = 0.4122214708f * R + 0.5363325363f * G + 0.0514459929f * B;
			float m = 0.2119034982f * R + 0.6806995451f * G + 0.1073969566f * B;
			float s = 0.0883024619f * R + 0.2817188376f * G + 0.6299787005f * B;
			float lRoot = Mathf.Pow(Mathf.Max(l, 0f), 1f / 3f);
			float mRoot = Mathf.Pow(Mathf.Max(m, 0f), 1f / 3f);
			float sRoot = Mathf.Pow(Mathf.Max(s, 0f), 1f / 3f);
			return new Oklab {
				L = 0.2104542553f * lRoot + 0.7936177850f * mRoot - 0.0040720468f * sRoot,
				a = 1.9779984951f * lRoot - 2.4285922050f * mRoot + 0.4505937099f * sRoot,
				b = 0.0259040371f * lRoot + 0.7827717662f * mRoot - 0.8086757662f * sRoot
			};
		}

		static Color OklabToRGB(Oklab TargetOklab, float Alpha) {
			float lRoot = TargetOklab.L + 0.3963377774f * TargetOklab.a + 0.2158037573f * TargetOklab.b;
			float mRoot = TargetOklab.L - 0.1055613458f * TargetOklab.a - 0.0638541728f * TargetOklab.b;
			float sRoot = TargetOklab.L - 0.0894841775f * TargetOklab.a - 1.2914855480f * TargetOklab.b;
			float l = lRoot * lRoot * lRoot;
			float m = mRoot * mRoot * mRoot;
			float s = sRoot * sRoot * sRoot;
			float R = +4.0767416621f * l - 3.3077115913f * m + 0.2309699292f * s;
			float G = -1.2684380046f * l + 2.6097574011f * m - 0.3413193965f * s;
			float B = -0.0041960863f * l - 0.7034186147f * m + 1.7076147010f * s;
			Color LinearColor = new Color(R, G, B, Alpha);
			Color SRGBColor = LinearColor.gamma;
			SRGBColor.a = Alpha;
			SRGBColor.r = Mathf.Clamp01(SRGBColor.r);
			SRGBColor.g = Mathf.Clamp01(SRGBColor.g);
			SRGBColor.b = Mathf.Clamp01(SRGBColor.b);
			return SRGBColor;
		}
	}
}
