using System;

using UnityEngine;

/*
 * Macchiato Core
 * Contact : crestudioplus@gmail.com // Twitter : https://twitter.com/VRC_Macchiato
 */

namespace Macchiato.Core {

	public static class MaterialUtility {

		public enum ShaderType {
			Unknown,
			lilToon,
			poiyomi,
			UnityChanToonShader
		}

		public static ShaderType GetShaderType(Material TargetMaterial) {
			string TargetShaderName = TargetMaterial.shader.name;
			if (TargetShaderName.Contains("lilToon", StringComparison.OrdinalIgnoreCase)) return ShaderType.lilToon;
			if (TargetShaderName.Contains("poiyomi", StringComparison.OrdinalIgnoreCase)) return ShaderType.poiyomi;
			if (TargetShaderName.Contains("UnityChanToonShader", StringComparison.OrdinalIgnoreCase)) return ShaderType.UnityChanToonShader;
			return ShaderType.Unknown;
		}

		public static bool HasOverriddenProperty(Material TargetMaterial, string TargetProperty) {
			if (!IsVariantMaterial(TargetMaterial)) return false;
			return TargetMaterial.IsPropertyOverriden(TargetProperty);
		}

		public static bool IsPropertyActive(Material TargetMaterial, string TargetPropertyName, bool CheckActive, float TargetValue = 1f) {
			if (!CheckActive) return true;
			if (!TargetMaterial.HasProperty(TargetPropertyName)) return false;
			if (Mathf.Approximately(TargetMaterial.GetFloat(TargetPropertyName), TargetValue)) return true;
			return false;
		}

		public static bool IsVariantMaterial(Material TargetMaterial) {
			return TargetMaterial && TargetMaterial.parent;
		}

		public static bool SetColorProperty(Material TargetMaterial, string TargetPropertyName, Color NewColor) {
			if (!TargetMaterial.HasProperty(TargetPropertyName)) return false;
			if (TargetMaterial.GetColor(TargetPropertyName) == NewColor) return false;
			TargetMaterial.SetColor(TargetPropertyName, NewColor);
			return true;
		}

		public static bool SetFloatProperty(Material TargetMaterial, string TargetPropertyName, float NewValue) {
			if (!TargetMaterial.HasProperty(TargetPropertyName)) return false;
			if (Mathf.Approximately(TargetMaterial.GetFloat(TargetPropertyName), NewValue)) return false;
			TargetMaterial.SetFloat(TargetPropertyName, NewValue);
			return true;
		}

		public static bool UpdateColorProperties(Material TargetMaterial, Material ReferenceMaterial, (string PropertyName, Color DefaultValue)[] TargetProperties) {
			bool IsDirty = false;
			foreach ((string PropertyName, Color DefaultValue) TargetProperty in TargetProperties) {
				bool HasReferenceValue = ReferenceMaterial && ReferenceMaterial.HasProperty(TargetProperty.PropertyName);
				Color NewValue = HasReferenceValue ? ReferenceMaterial.GetColor(TargetProperty.PropertyName) : TargetProperty.DefaultValue;
				if (SetColorProperty(TargetMaterial, TargetProperty.PropertyName, NewValue)) IsDirty = true;
			}
			return IsDirty;
		}

		public static bool UpdateFloatProperties(Material TargetMaterial, Material ReferenceMaterial, (string PropertyName, float DefaultValue)[] TargetProperties) {
			bool IsDirty = false;
			foreach ((string PropertyName, float DefaultValue) TargetProperty in TargetProperties) {
				bool HasReferenceValue = ReferenceMaterial && ReferenceMaterial.HasProperty(TargetProperty.PropertyName);
				float NewValue = HasReferenceValue ? ReferenceMaterial.GetFloat(TargetProperty.PropertyName) : TargetProperty.DefaultValue;
				if (SetFloatProperty(TargetMaterial, TargetProperty.PropertyName, NewValue)) IsDirty = true;
			}
			return IsDirty;
		}
	}
}