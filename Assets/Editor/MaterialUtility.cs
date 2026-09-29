using UnityEngine;

/*
 * Macchiato Core
 * Contact : crestudioplus@gmail.com // Twitter : https://twitter.com/VRC_Macchiato
 */

namespace Macchiato.Core {

	public static class MaterialUtility {

		public static bool SetFloatProperty(Material TargetMaterial, string TargetPropertyName, float NewValue) {
			if (!TargetMaterial.HasProperty(TargetPropertyName)) return false;
			if (Mathf.Approximately(TargetMaterial.GetFloat(TargetPropertyName), NewValue)) return false;
			TargetMaterial.SetFloat(TargetPropertyName, NewValue);
			return true;
		}

		public static bool SetColorProperty(Material TargetMaterial, string TargetPropertyName, Color NewColor) {
			if (!TargetMaterial.HasProperty(TargetPropertyName)) return false;
			if (TargetMaterial.GetColor(TargetPropertyName) == NewColor) return false;
			TargetMaterial.SetColor(TargetPropertyName, NewColor);
			return true;
		}
	}
}