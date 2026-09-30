using System;
using System.Collections.Generic;
using System.Linq;

using UnityEditor;
using UnityEngine;

using static Macchiato.Core.AvatarUtility;

/*
 * Macchiato Core
 * Contact : crestudioplus@gmail.com // Twitter : https://twitter.com/VRC_Macchiato
 */

namespace Macchiato.Core {

	public static class Translator {

		public static readonly string[] LanguageOption = new string[] { "English", "한국어", "日本語" };
		public static int LanguageIndex = 0;

		static Translator() {
			LanguageIndex = GetSystemLanguage();
		}

		static int GetSystemLanguage() {
			SystemLanguage TargetLanguage = Application.systemLanguage;
			switch (TargetLanguage) {
				case SystemLanguage.Korean:
					return 1;
				case SystemLanguage.Japanese:
					return 2;
				default:
					return 0;
			}
		}

		public static string GetTranslatedString(string TargetString) {
			string NewString = TargetString;
			switch (LanguageIndex) {
				case 0:
					if (String_English.ContainsKey(TargetString)) NewString = String_English[TargetString];
					break;
				case 1:
					if (String_Korean.ContainsKey(TargetString)) NewString = String_Korean[TargetString];
					break;
				case 2:
					if (String_Japanese.ContainsKey(TargetString)) NewString = String_Japanese[TargetString];
					break;
			}
			return NewString;
		}

		public static string[] GetAvatarAuthorName(SerializedProperty TargetProperty) {
			int AvatarAuthorCount = TargetProperty.arraySize;
			AvatarAuthor[] AvatarAuthorNames = new AvatarAuthor[AvatarAuthorCount];
			for (int Index = 0; Index < AvatarAuthorCount; Index++) {
				SerializedProperty ArrayItem = TargetProperty.GetArrayElementAtIndex(Index);
				string AvatarAuthorEnumName = ArrayItem.enumNames[ArrayItem.enumValueIndex];
				AvatarAuthorNames[Index] = (AvatarAuthor)Enum.Parse(typeof(AvatarAuthor), AvatarAuthorEnumName);
			}
			return AvatarAuthorNames
				.Where((AvatarAuthorName) => AvatarAuthorNameList.ContainsKey(AvatarAuthorName))
				.Select((AvatarAuthorName) => AvatarAuthorNameList[AvatarAuthorName][LanguageIndex])
				.ToArray();
		}

		public static string[] GetAvatarName(SerializedProperty TargetProperty) {
			int AvatarNameCount = TargetProperty.arraySize;
			AvatarType[] AvatarNames = new AvatarType[AvatarNameCount];
			for (int Index = 0; Index < AvatarNameCount; Index++) {
				SerializedProperty ArrayItem = TargetProperty.GetArrayElementAtIndex(Index);
				string AvatarEnumName = ArrayItem.enumNames[ArrayItem.enumValueIndex];
				AvatarNames[Index] = (AvatarType)Enum.Parse(typeof(AvatarType), AvatarEnumName);
			}
			return AvatarNames
				.Where((AvatarName) => AvatarNameList.ContainsKey(AvatarName))
				.Select((AvatarName) => AvatarNameList[AvatarName][LanguageIndex])
				.ToArray();
		}

		public static string[] GetLanguageOption() {
			switch (LanguageIndex) {
				case 0:
					return new string[] { "Auto", "English", "Korean", "Japanese" };
				case 1:
					return new string[] { "자동", "영어", "한국어", "일본어" };
				case 2:
					return new string[] { "自動", "英語", "韓国語", "日本語" };
				default:
					return new string[] { "Auto", "English", "Korean", "Japanese" };
			}
		}

		// 영어 사전 데이터
		static readonly Dictionary<string, string> String_English = new Dictionary<string, string>() {
			{ "String_Active", "Active" },
			{ "String_Add", "Add" },
			{ "String_After", "After" },
			{ "String_AnimationClip", "Animation Clip" },
			{ "String_AnimationOrigin", "Animation Origin" },
			{ "String_AnimationStrength", "Animation Strength" },
			{ "String_Apply", "Apply" },
			{ "String_Avatar", "Avatar" },
			{ "String_AvatarAuthor", "Avatar Author" },
			{ "String_AvatarOrigin", "Avatar Origin" },
			{ "String_Before", "Before" },
			{ "String_BlendShape", "Blendshape" },
			{ "String_Browse", "Browse" },
			{ "String_Close", "Close" },
			{ "String_FXLayer", "FX Layer" },
			{ "String_GetPosition", "Get cheek bone position" },
			{ "String_HeadMesh", "Face Mesh" },
			{ "String_Hide", "Hide" },
			{ "String_Language", "Language" },
			{ "String_Macchiato", "Macchiato" },
			{ "String_Material", "Materials" },
			{ "String_NewAvatar", "New Avatar" },
			{ "String_Okay", "OK" },
			{ "String_OldAvatar", "Original Avatar" },
			{ "String_Parameter", "Parameters" },
			{ "String_Path", "Path" },
			{ "String_Refresh", "Refresh" },
			{ "String_Reload", "Reload" },
			{ "String_Remove", "Remove" },
			{ "String_Replace", "Replace" },
			{ "String_Save", "Save" },
			{ "String_Show", "Show" },
			{ "String_Strength", "Strength" },
			{ "String_Texture", "Textures" },
			{ "String_Undo", "Undo" },
			{ "String_Update", "Update" },

			// GUIDUtility
			{ "String_InputGUID", "Please enter a GUID" },
			{ "NO_GUID", "Could not find an asset path for the specified GUID!" },

			// MaterialTemplate
			{ "String_ReferenceMaterial", "Reference Material" },
			{ "String_GetAvatarMaterials", "Get Avatar Materials" },

			{ "String_Common", "General" },
			{ "String_DeepCopy", "Deep Copy" },
			{ "String_None", "Deselect" },

			{ "String_UpdatelilToonBasic", "Update Basic" },
			{ "String_UpdatelilToonLighting", "Update Lighting" },
			{ "String_UpdatelilToonAlpha", "Update Alpha" },
			{ "String_UpdatelilToonShadow", "Update Shadow" },
			{ "String_UpdatelilToonRimShade", "Update Rim Shade" },
			{ "String_UpdatelilToonEmission1", "Update Emission 1" },
			{ "String_UpdatelilToonEmission2", "Update Emission 2" },
			{ "String_UpdatelilToonAnisotropy", "Update Anisotropy" },
			{ "String_UpdatelilToonBacklight", "Update Backlight" },
			{ "String_UpdatelilToonReflection", "Update Reflection" },
			{ "String_UpdatelilToonMatCap1", "Update MatCap 1" },
			{ "String_UpdatelilToonMatCap2", "Update MatCap 2" },
			{ "String_UpdatelilToonRimLight", "Update Rim Light" },
			{ "String_UpdatelilToonGlitter", "Update Glitter" },
			{ "String_UpdatelilToonOutline", "Update Outline" },
			{ "String_UpdatelilToonParallax", "Update Parallax" },
			{ "String_UpdatelilToonDistanceFade", "Update Distance Fade" },
			{ "String_UpdatelilToonAudioLink", "Update AudioLink" },
			{ "String_UpdatelilToonDissolve", "Update Dissolve" },
			{ "String_UpdatelilToonIDMask", "Update ID Mask" },
			{ "String_UpdatelilToonUVTileDiscard", "Update UV Tile Discard" },
			{ "String_UpdatelilToonStencil", "Update Stencil" },
			{ "String_UpdatelilToonRendering", "Update Rendering" },
			{ "String_UpdatelilToonTessellation", "Update Tessellation" },
			{ "String_ForcelilToonShadow", "Force Shadow" },
			{ "String_ForcelilToonRimShade", "Force Rim Shade" },
			{ "String_ForcelilToonEmission1", "Force Emission 1" },
			{ "String_ForcelilToonEmission2", "Force Emission 2" },
			{ "String_ForcelilToonAnisotropy", "Force Anisotropy" },
			{ "String_ForcelilToonBacklight", "Force Backlight" },
			{ "String_ForcelilToonReflection", "Force Reflection" },
			{ "String_ForcelilToonMatCap1", "Force MatCap 1" },
			{ "String_ForcelilToonMatCap2", "Force MatCap 2" },
			{ "String_ForcelilToonRimLight", "Force Rim Light" },
			{ "String_ForcelilToonGlitter", "Force Glitter" },
			{ "String_ForcelilToonParallax", "Force Parallax" },
			{ "String_ForcelilToonAudioLink", "Force AudioLink" },
			{ "String_ForcelilToonUVTileDiscard", "Force UV Tile Discard" },
			{ "String_UpdatelilToonBackfaceColor", "Update Backface Color" },
			{ "String_TargetBackfaceColor", "Backface Color" },
			{ "String_UpdatelilToonShadowColor", "Update Shadow Color" },
			{ "String_TargetShadow1Color", "Shadow 1 Color" },
			{ "String_TargetShadow2Color", "Shadow 2 Color" },
			{ "String_TargetShadow3Color", "Shadow 3 Color" },
			{ "String_TargetShadowBorderColor", "Shadow Border Color" },
			{ "String_UpdatelilToonRimShadeColor", "Update Rim Shade Color" },
			{ "String_TargetRimShadeColor", "Rim Shade Color" },
			{ "String_UpdatelilToonEmission1Color", "Update Emission 1 Color" },
			{ "String_TargetEmission1Color", "Emission 1 Color" },
			{ "String_UpdatelilToonEmission2Color", "Update Emission 2 Color" },
			{ "String_TargetEmission2Color", "Emission 2 Color" },
			{ "String_UpdatelilToonBacklightColor", "Update Backlight Color" },
			{ "String_TargetBacklightColor", "Backlight Color" },
			{ "String_UpdatelilToonReflectionColor", "Update Reflection Color" },
			{ "String_TargetReflectionColor", "Reflection Color" },
			{ "String_UpdatelilToonMatCap1Color", "Update MatCap 1 Color" },
			{ "String_TargetMatCap1Color", "MatCap 1 Color" },
			{ "String_UpdatelilToonMatCap2Color", "Update MatCap 2 Color" },
			{ "String_TargetMatCap2Color", "MatCap 2 Color" },
			{ "String_UpdatelilToonRimLightColor", "Update Rim Light Color" },
			{ "String_TargetRimLightColor", "Rim Light Color" },
			{ "String_UpdatelilToonGlitterColor", "Update Glitter Color" },
			{ "String_TargetGlitterColor", "Glitter Color" },
			{ "String_UpdatelilToonOutlineColor", "Update Outline Color" },
			{ "String_TargetOutlineColor", "Outline Color" },
			{ "String_TargetOutlineHighlightColor", "Outline Highlight Color" },
			{ "String_UpdatelilToonDistanceFadeColor", "Update Distance Fade Color" },
			{ "String_TargetDistanceFadeColor", "Distance Fade Color" },
			{ "String_TargetDistanceFadeRimColor", "Distance Fade Rim Color" },

			{ "String_General", "General" },
			{ "String_RenderQueue", "Reset Render Queue" },
			{ "String_GPUInstancing", "Update GPU Instancing" },
			{ "String_GlobalIllumination", "Update Global Illumination" },

			{ "COMPLETED_UPDATEMATERIAL", "Modified {0} materials" },
			{ "NOT_SUPPORT_SHADER", "{0} shader is not supported"},

			// TextureReplacer
			{ "String_Null", "Clearing the item will remove the texture from the material" },
			{ "NO_DATA", "The texture cannot be found in the specified object" },

			// 성공 코드
			{ "COMPLETED_GETPOSITION", "Imported cheek bone origin position" },
			{ "COMPLETED_UPDATE", "Updated the offset of the animation clip" },

			// 에러 코드
			{ "NO_ANIMATOR", "Not found Animator Component in the Avatar!" },
			{ "NO_ANIMSHAPEKEY", "There are no face-related shape keys in the FX layer animation" },
			{ "NO_CHEEKBONE", "Not found any cheek bone in the Avatar!" },
			{ "NO_CLIPS", "There is no animation clip to update!" },
			{ "NO_FACEMESH", "Face mesh not found" },
			{ "NO_PREFAB_MODE", "This operation is not available in Prefab Mode" },
			{ "NO_SHAPEKEY", "No shapekeys with values set" }
		};

		// 한국어 사전 데이터
		static readonly Dictionary<string, string> String_Korean = new Dictionary<string, string>() {
			{ "String_Active", "활성화" },
			{ "String_Add", "추가" },
			{ "String_After", "변경 후" },
			{ "String_AnimationClip", "애니메이션 클립" },
			{ "String_AnimationOrigin", "애니메이션 본 원점" },
			{ "String_AnimationStrength", "애니메이션 강도" },
			{ "String_Apply", "적용" },
			{ "String_Avatar", "아바타" },
			{ "String_AvatarAuthor", "아바타 제작자" },
			{ "String_AvatarOrigin", "아바타 볼 원점" },
			{ "String_Before", "변경 전" },
			{ "String_BlendShape", "쉐이프키" },
			{ "String_Browse", "찾아보기" },
			{ "String_Close", "닫기" },
			{ "String_FXLayer", "FX 레이어" },
			{ "String_GetPosition", "볼 데이터 가져오기" },
			{ "String_HeadMesh", "얼굴 메쉬" },
			{ "String_Hide", "숨기기" },
			{ "String_Language", "언어" },
			{ "String_Macchiato", "마끼아또" },
			{ "String_Material", "머테리얼" },
			{ "String_NewAvatar", "신규 아바타" },
			{ "String_Okay", "확인" },
			{ "String_OldAvatar", "원본 아바타" },
			{ "String_Parameter", "파라메터" },
			{ "String_Path", "경로" },
			{ "String_Refresh", "새로 고침" },
			{ "String_Reload", "다시 불러오기" },
			{ "String_Remove", "삭제" },
			{ "String_Replace", "교체" },
			{ "String_Save", "저장" },
			{ "String_Show", "표시" },
			{ "String_Strength", "강도" },
			{ "String_Texture", "텍스쳐" },
			{ "String_Undo", "실행 취소" },
			{ "String_Update", "업데이트" },

			// GUIDUtility
			{ "String_InputGUID", "GUID를 입력해 주세요" },
			{ "NO_GUID", "해당 GUID의 에셋 경로를 찾을 수 없습니다!" },

			// MaterialTemplate
			{ "String_ReferenceMaterial", "참조 머티리얼" },
			{ "String_GetAvatarMaterials", "아바타 머티리얼 가져오기" },

			{ "String_Common", "일반" },
			{ "String_DeepCopy", "모두 복사" },
			{ "String_None", "선택 해제" },

			{ "String_UpdatelilToonBasic", "기본 업데이트" },
			{ "String_UpdatelilToonLighting", "라이팅 업데이트" },
			{ "String_UpdatelilToonAlpha", "알파 업데이트" },
			{ "String_UpdatelilToonShadow", "그림자 업데이트" },
			{ "String_UpdatelilToonRimShade", "림 쉐이드 업데이트" },
			{ "String_UpdatelilToonEmission1", "발광 1 업데이트" },
			{ "String_UpdatelilToonEmission2", "발광 2 업데이트" },
			{ "String_UpdatelilToonAnisotropy", "애니소트로픽 업데이트" },
			{ "String_UpdatelilToonBacklight", "역광 업데이트" },
			{ "String_UpdatelilToonReflection", "광택 업데이트" },
			{ "String_UpdatelilToonMatCap1", "매트 캡 1 업데이트" },
			{ "String_UpdatelilToonMatCap2", "매트 캡 2 업데이트" },
			{ "String_UpdatelilToonRimLight", "림 라이트 업데이트" },
			{ "String_UpdatelilToonGlitter", "글리터 업데이트" },
			{ "String_UpdatelilToonOutline", "윤곽선  업데이트" },
			{ "String_UpdatelilToonParallax", "시차 업데이트" },
			{ "String_UpdatelilToonDistanceFade", "거리 페이드 업데이트" },
			{ "String_UpdatelilToonAudioLink", "AudioLink 업데이트" },
			{ "String_UpdatelilToonDissolve", "디졸브 업데이트" },
			{ "String_UpdatelilToonIDMask", "ID 마스크 업데이트" },
			{ "String_UpdatelilToonUVTileDiscard", "UV 타일 삭제 업데이트" },
			{ "String_UpdatelilToonStencil", "스텐실 업데이트" },
			{ "String_UpdatelilToonRendering", "렌더링 업데이트" },
			{ "String_UpdatelilToonTessellation", "테셀레이션 업데이트" },

			{ "String_ForcelilToonShadow", "그림자 강제 적용" },
			{ "String_ForcelilToonRimShade", "림 쉐이드 강제 적용" },
			{ "String_ForcelilToonEmission1", "발광 1 강제 적용" },
			{ "String_ForcelilToonEmission2", "발광 2 강제 적용" },
			{ "String_ForcelilToonAnisotropy", "애니소트로픽 강제 적용" },
			{ "String_ForcelilToonBacklight", "역광 강제 적용" },
			{ "String_ForcelilToonReflection", "광택 강제 적용" },
			{ "String_ForcelilToonMatCap1", "매트 캡 1 강제 적용" },
			{ "String_ForcelilToonMatCap2", "매트 캡 2 강제 적용" },
			{ "String_ForcelilToonRimLight", "림 라이트 강제 적용" },
			{ "String_ForcelilToonGlitter", "글리터 강제 적용" },
			{ "String_ForcelilToonParallax", "시차 강제 적용" },
			{ "String_ForcelilToonAudioLink", "AudioLink 강제 적용" },
			{ "String_ForcelilToonUVTileDiscard", "UV 타일 삭제 강제 적용" },

			{ "String_UpdatelilToonBackfaceColor", "뒷면 색상 업데이트" },
			{ "String_TargetBackfaceColor", "뒷면 색상" },
			{ "String_UpdatelilToonShadowColor", "그림자 색상 업데이트" },
			{ "String_TargetShadow1Color", "그림자 1 색상" },
			{ "String_TargetShadow2Color", "그림자 2 색상" },
			{ "String_TargetShadow3Color", "그림자 3 색상" },
			{ "String_TargetShadowBorderColor", "그림자 경계 색상" },
			{ "String_UpdatelilToonRimShadeColor", "림 쉐이드 색상 업데이트" },
			{ "String_TargetRimShadeColor", "림 쉐이드 색상" },
			{ "String_UpdatelilToonEmission1Color", "발광 1 색상 업데이트" },
			{ "String_TargetEmission1Color", "발광 1 색상" },
			{ "String_UpdatelilToonEmission2Color", "발광 2 색상 업데이트" },
			{ "String_TargetEmission2Color", "발광 2 색상" },
			{ "String_UpdatelilToonBacklightColor", "역광 색상 업데이트" },
			{ "String_TargetBacklightColor", "역광 색상" },
			{ "String_UpdatelilToonReflectionColor", "광택 색상 업데이트" },
			{ "String_TargetReflectionColor", "광택 색상" },
			{ "String_UpdatelilToonMatCap1Color", "매트 캡 1 색상 업데이트" },
			{ "String_TargetMatCap1Color", "매트 캡 1 색상" },
			{ "String_UpdatelilToonMatCap2Color", "매트 캡 2 색상 업데이트" },
			{ "String_TargetMatCap2Color", "매트 캡 2 색상" },
			{ "String_UpdatelilToonRimLightColor", "림 라이트 색상 업데이트" },
			{ "String_TargetRimLightColor", "림 라이트 색상" },
			{ "String_UpdatelilToonGlitterColor", "글리터 색상 업데이트" },
			{ "String_TargetGlitterColor", "글리터 색상" },
			{ "String_UpdatelilToonOutlineColor", "윤곽선 색상 업데이트" },
			{ "String_TargetOutlineColor", "윤곽선 색상" },
			{ "String_TargetOutlineHighlightColor", "윤곽선 하이라이트 색상" },
			{ "String_UpdatelilToonDistanceFadeColor", "거리 페이드 색상 업데이트" },
			{ "String_TargetDistanceFadeColor", "거리 페이드 색상" },
			{ "String_TargetDistanceFadeRimColor", "거리 페이드 림 색상" },

			{ "String_General", "일반" },
			{ "String_RenderQueue", "Render Queue 초기화" },
			{ "String_GPUInstancing", "GPU Instancing 업데이트" },
			{ "String_GlobalIllumination", "Global Illumination 업데이트" },

			{ "COMPLETED_UPDATEMATERIAL", "{0}개의 머티리얼이 수정되었습니다" },
			{ "NOT_SUPPORT_SHADER", "{0} 셰이더는 지원하지 않습니다" },

			// TextureReplacer
			{ "String_Null", "항목을 비우면 해당 텍스쳐를 머테리얼에서 제거합니다" },
			{ "NO_DATA", "해당 오브젝트에서 텍스쳐를 찾을 수 없습니다" },

			// 성공 코드
			{ "COMPLETED_GETPOSITION", "볼 위치 데이터를 가져왔습니다" },
			{ "COMPLETED_UPDATE", "애니메이션 클립의 오프셋을 업데이트 하였습니다" },

			// 에러 코드
			{ "NO_ANIMATOR", "아바타에서 애니메이터를 찾을 수 없습니다!" },
			{ "NO_ANIMSHAPEKEY", "FX 레이어의 애니메이션에서 얼굴 관련 쉐이프키가 없습니다" },
			{ "NO_CHEEKBONE", "아바타에서 볼 본을 찾을 수 없습니다!" },
			{ "NO_CLIPS", "작업할 애니메이션 클립이 없습니다!" },
			{ "NO_FACEMESH", "얼굴 메쉬를 찾을 수 없습니다" },
			{ "NO_PREFAB_MODE", "Prefab 편집 모드에서는 진행할 수 없습니다" },
			{ "NO_SHAPEKEY", "값이 설정된 쉐이프키가 없습니다" }
		};

		// 일본어 사전 데이터
		static readonly Dictionary<string, string> String_Japanese = new Dictionary<string, string>() {
			{ "String_Active", "有効化" },
			{ "String_Add", "追加" },
			{ "String_After", "変更" },
			{ "String_AnimationClip", "アニメーション·クリップ" },
			{ "String_AnimationOrigin", "アニメーションほっぺの原点" },
			{ "String_AnimationStrength", "アニメーション強盗" },
			{ "String_Apply", "適用" },
			{ "String_Avatar", "アバター" },
			{ "String_AvatarAuthor", "アバター製作者" },
			{ "String_AvatarOrigin", "アバターほっぺの原点" },
			{ "String_Before", "既存" },
			{ "String_BlendShape", "シェイプキー" },
			{ "String_Browse", "参照" },
			{ "String_Close", "閉じる" },
			{ "String_FXLayer", "FXレイヤー" },
			{ "String_GetPosition", "ほっぺデータのインポート" },
			{ "String_HeadMesh", "顔メッシュ" },
			{ "String_Hide", "非表示" },
			{ "String_Language", "言語" },
			{ "String_Macchiato", "マキアート" },
			{ "String_Material", "マテリアル" },
			{ "String_NewAvatar", "新規アバター" },
			{ "String_Okay", "確認" },
			{ "String_OldAvatar", "原本アバター" },
			{ "String_Parameter", "パラメータ" },
			{ "String_Path", "パス" },
			{ "String_Refresh", "更新" },
			{ "String_Reload", "リロード" },
			{ "String_Remove", "削除" },
			{ "String_Replace", "交換" },
			{ "String_Save", "保存" },
			{ "String_Show", "表示" },
			{ "String_Strength", "強度" },
			{ "String_Texture", "テクスチャ" },
			{ "String_Undo", "元に戻す" },
			{ "String_Update", "アップデート" },

			// GUIDUtility
			{ "String_InputGUID", "GUIDを入力してください" },
			{ "NO_GUID", "指定されたGUIDのアセットパスが見つかりません!" },

			// MaterialTemplate
			{ "String_ReferenceMaterial", "参照マテリアル" },
			{ "String_GetAvatarMaterials", "アバターのマテリアルを取得" },

			{ "String_Common", "一般" },
			{ "String_DeepCopy", "すべてコピー" },
			{ "String_None", "選択解除" },

			{ "String_UpdatelilToonBasic", "基本を更新" },
			{ "String_UpdatelilToonLighting", "ライティングを更新" },
			{ "String_UpdatelilToonAlpha", "アルファを更新" },
			{ "String_UpdatelilToonShadow", "影を更新" },
			{ "String_UpdatelilToonRimShade", "リムシェードを更新" },
			{ "String_UpdatelilToonEmission1", "発光１を更新" },
			{ "String_UpdatelilToonEmission2", "発光２を更新" },
			{ "String_UpdatelilToonAnisotropy", "異方性反射を更新" },
			{ "String_UpdatelilToonBacklight", "逆光ライトを更新" },
			{ "String_UpdatelilToonReflection", "光沢を更新" },
			{ "String_UpdatelilToonMatCap1", "マットキャップ１を更新" },
			{ "String_UpdatelilToonMatCap2", "マットキャップ２を更新" },
			{ "String_UpdatelilToonRimLight", "リムライトを更新" },
			{ "String_UpdatelilToonGlitter", "ラメを更新" },
			{ "String_UpdatelilToonOutline", "輪郭線を更新" },
			{ "String_UpdatelilToonParallax", "視差を更新" },
			{ "String_UpdatelilToonDistanceFade", "距離フェードを更新" },
			{ "String_UpdatelilToonAudioLink", "AudioLinkを更新" },
			{ "String_UpdatelilToonDissolve", "Dissolveを更新" },
			{ "String_UpdatelilToonIDMask", "ID Maskを更新" },
			{ "String_UpdatelilToonUVTileDiscard", "UV Tile Discardを更新" },
			{ "String_UpdatelilToonStencil", "ステンシルを更新" },
			{ "String_UpdatelilToonRendering", "レンダリングを更新" },
			{ "String_UpdatelilToonTessellation", "テッセレーションを更新" },

			{ "String_ForcelilToonShadow", "影を強制適用" },
			{ "String_ForcelilToonRimShade", "リムシェードを強制適用" },
			{ "String_ForcelilToonEmission1", "発光１を強制適用" },
			{ "String_ForcelilToonEmission2", "発光２を強制適用" },
			{ "String_ForcelilToonAnisotropy", "異方性反射を強制適用" },
			{ "String_ForcelilToonBacklight", "逆光ライトを強制適用" },
			{ "String_ForcelilToonReflection", "光沢を強制適用" },
			{ "String_ForcelilToonMatCap1", "マットキャップ１を強制適用" },
			{ "String_ForcelilToonMatCap2", "マットキャップ２を強制適用" },
			{ "String_ForcelilToonRimLight", "リムライトを強制適用" },
			{ "String_ForcelilToonGlitter", "ラメを強制適用" },
			{ "String_ForcelilToonParallax", "視差を強制適用" },
			{ "String_ForcelilToonAudioLink", "AudioLinkを強制適用" },
			{ "String_ForcelilToonUVTileDiscard", "UV Tile Discardを強制適用" },

			{ "String_UpdatelilToonBackfaceColor", "裏面の色を更新" },
			{ "String_TargetBackfaceColor", "裏面の色" },
			{ "String_UpdatelilToonShadowColor", "影の色を更新" },
			{ "String_TargetShadow1Color", "影１の色" },
			{ "String_TargetShadow2Color", "影２の色" },
			{ "String_TargetShadow3Color", "影３の色" },
			{ "String_TargetShadowBorderColor", "影の境界色" },
			{ "String_UpdatelilToonRimShadeColor", "リムシェードの色を更新" },
			{ "String_TargetRimShadeColor", "リムシェードの色" },
			{ "String_UpdatelilToonEmission1Color", "発光１の色を更新" },
			{ "String_TargetEmission1Color", "発光１の色" },
			{ "String_UpdatelilToonEmission2Color", "発光２の色を更新" },
			{ "String_TargetEmission2Color", "発光２の色" },
			{ "String_UpdatelilToonBacklightColor", "逆光ライトの色を更新" },
			{ "String_TargetBacklightColor", "逆光ライトの色" },
			{ "String_UpdatelilToonReflectionColor", "光沢の色を更新" },
			{ "String_TargetReflectionColor", "光沢の色" },
			{ "String_UpdatelilToonMatCap1Color", "マットキャップ１の色を更新" },
			{ "String_TargetMatCap1Color", "マットキャップ１の色" },
			{ "String_UpdatelilToonMatCap2Color", "マットキャップ２の色を更新" },
			{ "String_TargetMatCap2Color", "マットキャップ２の色" },
			{ "String_UpdatelilToonRimLightColor", "リムライトの色を更新" },
			{ "String_TargetRimLightColor", "リムライトの色" },
			{ "String_UpdatelilToonGlitterColor", "ラメの色を更新" },
			{ "String_TargetGlitterColor", "ラメの色" },
			{ "String_UpdatelilToonOutlineColor", "輪郭線の色を更新" },
			{ "String_TargetOutlineColor", "輪郭線の色" },
			{ "String_TargetOutlineHighlightColor", "輪郭線ハイライトの色" },
			{ "String_UpdatelilToonDistanceFadeColor", "距離フェードの色を更新" },
			{ "String_TargetDistanceFadeColor", "距離フェードの色" },
			{ "String_TargetDistanceFadeRimColor", "距離フェードリムライトの色" },

			{ "String_General", "一般" },
			{ "String_RenderQueue", "Render Queueをリセット" },
			{ "String_GPUInstancing", "GPU Instancingを更新" },
			{ "String_GlobalIllumination", "Global Illuminationを更新" },

			{ "COMPLETED_UPDATEMATERIAL", "{0}個のマテリアルを変更しました" },
			{ "NOT_SUPPORT_SHADER", "{0}シェーダーはサポートしていません" },

			// TextureReplacer
			{ "String_Null", "項目をクリアすると、該当テクスチャがマテリアルから削除されます" },
			{ "NO_DATA", "該当オブジェクトでテクスチャを見つけることができません" },

			// 성공 코드
			{ "COMPLETED_GETPOSITION", "ほっぺ位置データを取得しました" },
			{ "COMPLETED_UPDATE", "アニメーション·クリップのオフセットを更新しました" },

			// 에러 코드
			{ "NO_ANIMATOR", "アバターにアニメーターが見つかりません" },
			{ "NO_ANIMSHAPEKEY", "FXレイヤーのアニメーションで顔関連のシェイプキーがありません" },
			{ "NO_CHEEKBONE", "アバターにほっぺの骨が見つかりません！" },
			{ "NO_CLIPS", "作業するアニメーション·クリップがありません！" },
			{ "NO_FACEMESH", "顔のメッシュが見つかりません" },
			{ "NO_PREFAB_MODE", "Prefab編集モードでは実行できません" },
			{ "NO_SHAPEKEY", "値が設定されたシェイプキーがありません" }
		};

		static readonly Dictionary<AvatarAuthor, string[]> AvatarAuthorNameList = new Dictionary<AvatarAuthor, string[]>() {
			{ AvatarAuthor.General, new string[] { "General", "일반", "一般" } },
			{ AvatarAuthor.ChocolateRice, new string[] { "Chocolate rice", "초콜렛 라이스", "チョコレートライス" } },
			{ AvatarAuthor.JINGO, new string[] { "JINGO", "진권", "ジンゴ" } },
			{ AvatarAuthor.Komado, new string[] { "Komado", "코마도", "こまど" } },
			{ AvatarAuthor.Plusone, new string[] { "Plusone", "플러스원", "ぷらすわん" } }
		};

		static readonly Dictionary<AvatarType, string[]> AvatarNameList = new Dictionary<AvatarType, string[]>() {
			{ AvatarType.General, new string[] { "General", "일반", "一般" } },
			{ AvatarType.None, new string[] { "None", "없음", "無い" } },
			{ AvatarType.Airi, new string[] { "Airi", "아이리", "愛莉" } },
			{ AvatarType.Aldina, new string[] { "Aldina", "알디나", "アルディナ" } },
			{ AvatarType.Angura, new string[] { "Angura", "앙그라", "アングラ" } },
			{ AvatarType.Anon, new string[] { "Anon", "아논", "あのん" } },
			{ AvatarType.Anri, new string[] { "Anri", "안리", "杏里" } },
			{ AvatarType.Ash, new string[] { "Ash", "애쉬", "アッシュ" } },
			{ AvatarType.Chiffon, new string[] { "Chiffon", "쉬폰", "シフォン" } },
			{ AvatarType.Chise, new string[] { "Chise", "치세", "チセ" } },
			{ AvatarType.Chocolat, new string[] { "Chocolat", "쇼콜라", "ショコラ" } },
			{ AvatarType.Cygnet, new string[] { "Cygnet", "시그넷", "シグネット" } },
			{ AvatarType.Eku, new string[] { "Eku", "에쿠", "エク" } },
			{ AvatarType.Emmelie, new string[] { "Emmelie", "에밀리", "Emmelie" } },
			{ AvatarType.EYO, new string[] { "EYO", "이요", "イヨ" } },
			{ AvatarType.Firina, new string[] { "Firina", "휘리나", "フィリナ" } },
			{ AvatarType.Flare, new string[] { "Flare", "플레어", "フレア" } },
			{ AvatarType.Fuzzy, new string[] { "Fuzzy", "퍼지", "ファジー" } },
			{ AvatarType.Glaze, new string[] { "Glaze", "글레이즈", "ぐれーず" } },
			{ AvatarType.Grus, new string[] { "Grus", "그루스", "Grus" } },
			{ AvatarType.Hakka, new string[] { "Hakka", "하카", "薄荷" } },
			{ AvatarType.IMERIS, new string[] { "IMERIS", "이메리스", "イメリス" } },
			{ AvatarType.Karin, new string[] { "Karin", "카린", "カリン" } },
			{ AvatarType.Kikyo, new string[] { "Kikyo", "키쿄", "桔梗" } },
			{ AvatarType.Kipfel, new string[] { "Kipfel", "키펠", "キプフェル" } },
			{ AvatarType.Kokoa, new string[] { "Kokoa", "코코아", "ここあ" } },
			{ AvatarType.Koyuki, new string[] { "Koyuki", "코유키", "狐雪" } },
			{ AvatarType.KUMALY, new string[] { "KUMALY", "쿠마리", "クマリ" } },
			{ AvatarType.Kuronatu, new string[] { "Kuronatu", "쿠로나츠", "くろなつ" } },
			{ AvatarType.Lapwing, new string[] { "Lapwing", "랩윙", "Lapwing" } },
			{ AvatarType.Lazuli, new string[] { "Lazuli", "라줄리", "ラズリ" } },
			{ AvatarType.Leefa, new string[] { "Leefa", "리파", "リーファ" } },
			{ AvatarType.Leeme, new string[] { "Leeme", "리메", "リーメ" } },
			{ AvatarType.Lime, new string[] { "Lime", "라임", "ライム" } },
			{ AvatarType.LUMINA, new string[] { "LUMINA", "루미나", "ルミナ" } },
			{ AvatarType.Lunalitt, new string[] { "Lunalitt", "루나릿트", "ルーナリット" } },
			{ AvatarType.Mafuyu, new string[] { "Mafuyu", "마후유", "真冬" } },
			{ AvatarType.Maki, new string[] { "Maki", "마키", "碼希" } },
			{ AvatarType.Mamehinata, new string[] { "Mamehinata", "마메히나타", "まめひなた" } },
			{ AvatarType.MANUKA, new string[] { "MANUKA", "마누카", "マヌカ" } },
			{ AvatarType.Mariel, new string[] { "Mariel", "마리엘", "まりえる" } },
			{ AvatarType.Marron, new string[] { "Marron", "마론", "マロン" } },
			{ AvatarType.Maya, new string[] { "Maya", "마야", "舞夜" } },
			{ AvatarType.MAYO, new string[] { "MAYO", "마요", "まよ" } },
			{ AvatarType.Merino, new string[] { "Merino", "메리노", "メリノ" } },
			{ AvatarType.MICA, new string[] { "MICA", "미카", "ミカ" } },
			{ AvatarType.Milfy, new string[] { "Milfy", "미르피", "ミルフィ" } },
			{ AvatarType.Milk, new string[] { "Milk(New)", "밀크(신)", "ミルク（新）" } },
			{ AvatarType.Milltina, new string[] { "Milltina", "밀티나", "ミルティナ" } },
			{ AvatarType.Minahoshi, new string[] { "Minahoshi", "미나호시", "みなほし" } },
			{ AvatarType.Minase, new string[] { "Minase", "미나세", "水瀬" } },
			{ AvatarType.Mint, new string[] { "Mint", "민트", "ミント" } },
			{ AvatarType.Mir, new string[] { "Mir", "미르", "ミール" } },
			{ AvatarType.Misaki, new string[] { "Misaki", "미사키", "海咲" } },
			{ AvatarType.Mishe, new string[] { "Mishe", "미셰", "ミーシェ" } },
			{ AvatarType.Moe, new string[] { "Moe", "모에", "萌" } },
			{ AvatarType.Nayu, new string[] { "Nayu", "나유", "ナユ" } },
			{ AvatarType.Nehail, new string[] { "Nehail", "네하일", "ネハイル" } },
			{ AvatarType.Nochica, new string[] { "Nochica", "노치카", "ノーチカ" } },
			{ AvatarType.Platinum, new string[] { "Platinum", "플레티늄", "プラチナ" } },
			{ AvatarType.Plum, new string[] { "Plum", "플럼", "プラム" } },
			{ AvatarType.Pochimaru, new string[] { "Pochimaru", "포치마루", "ぽちまる" } },
			{ AvatarType.Quiche, new string[] { "Quiche", "킷슈", "キッシュ" } },
			{ AvatarType.Rainy, new string[] { "Rainy", "레이니", "レイニィ" } },
			{ AvatarType.Ramune, new string[] { "Ramune", "라무네", "ラムネ" } },
			{ AvatarType.Ramune_Old, new string[] { "Ramune(Old)", "라무네(구)", "ラムネ（古）" } },
			{ AvatarType.RINDO, new string[] { "RINDO", "린도", "竜胆" } },
			{ AvatarType.Rokona, new string[] { "Rokona", "로코나", "ロコナ" } },
			{ AvatarType.Rue, new string[] { "Rue", "루에", "ルウ" } },
			{ AvatarType.Rurune, new string[] { "Rurune", "루루네", "ルルネ" } },
			{ AvatarType.Rusk, new string[] { "Rusk", "러스크", "ラスク" } },
			{ AvatarType.SELESTIA, new string[] { "SELESTIA", "셀레스티아", "セレスティア" } },
			{ AvatarType.Sephira, new string[] { "Sephira", "세피라", "セフィラ" } },
			{ AvatarType.Shami, new string[] { "Shami", "샤미", "シャミ" } },
			{ AvatarType.Shinano, new string[] { "Shinano", "시나노", "しなの" } },
			{ AvatarType.Shinra, new string[] { "Shinra", "신라", "森羅" } },
			{ AvatarType.SHIRAHA, new string[] { "SHIRAHA", "시라하", "シラハ" } },
			{ AvatarType.Shiratsume, new string[] { "Shiratsume", "시라츠메", "しらつめ" } },
			{ AvatarType.Sio, new string[] { "Sio", "시오", "しお" } },
			{ AvatarType.Sue, new string[] { "Sue", "스우", "透羽" } },
			{ AvatarType.Sugar, new string[] { "Sugar", "슈가", "シュガ" } },
			{ AvatarType.Suzuhana, new string[] { "Suzuhana", "스즈하나", "すずはな" } },
			{ AvatarType.Tien, new string[] { "Tien", "티엔", "ティエン" } },
			{ AvatarType.TubeRose, new string[] { "TubeRose", "튜베로즈", "TubeRose" } },
			{ AvatarType.Ukon, new string[] { "Ukon", "우콘", "右近" } },
			{ AvatarType.Usasaki, new string[] { "Usasaki", "우사사키", "うささき" } },
			{ AvatarType.Uzuki, new string[] { "Uzuki", "우즈키", "卯月" } },
			{ AvatarType.VIVH, new string[] { "VIVH", "비브", "ビィブ" } },
			{ AvatarType.Wolferia, new string[] { "Wolferia", "울페리아", "ウルフェリア" } },
			{ AvatarType.Yoll, new string[] { "Yoll", "요루", "ヨル" } },
			{ AvatarType.YUGI_MIYO, new string[] { "YUGI MIYO", "유기 미요", "ユギ ミヨ" } },
			{ AvatarType.Yuuko, new string[] { "Yuuko", "유우코", "幽狐" } }
			// 검색용 신규 아바타 추가 위치
		};
	}
}