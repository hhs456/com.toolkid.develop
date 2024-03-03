using System;
using System.IO;
using UnityEditor;
using UnityEngine;

public class ScriptTemplateProcessor : AssetModificationProcessor {

    // 非使用者操作而產生資源時將會呼叫此函式，eg. ".meta" 檔案
    // 需使用 static 修飾詞
    static void OnWillCreateAsset(string path) {
        // 移除.meta extention字串
        path = path.Replace(".meta", "");

        // 檢測路徑的副檔名
        if (Path.GetExtension(path) != ".cs") {
            return;
        }
        
        // 取得腳本路徑
        var index = Application.dataPath.LastIndexOf("Assets");
        path = Application.dataPath.Substring(0, index) + path;
        Debug.Log(path);
        // 取得腳本名稱
        var fileName = Path.GetFileNameWithoutExtension(path);

        if (File.Exists(path)) {
            // 轉換關鍵字
            var content = File.ReadAllText(path);
            ReplaceKeyword(fileName, ref content);

            //// 覆寫檔案並重新整理資源
            File.WriteAllText(path, content);
            AssetDatabase.Refresh();
        }
    }
    // 轉換關鍵字
    static void ReplaceKeyword(string fileName, ref string script) {        
        // 將原檔名的 "Editor" 置換為 "" ，再將此字串取代 "#TargetScriptName#"
        script = script.Replace("#TARKETNAME#", fileName.Replace("Editor", ""));
    }
    public class RestartScriptProcessor : AssetPostprocessor {
        static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] mocedFromAssetPaths, bool didDomainReload) {
            bool enableRestart = false;
            foreach (var asset in importedAssets) {
                if (asset.EndsWith("ScriptTemplates")) {
                    enableRestart = true;
                }
            }
            if (enableRestart) {
                bool userConfirmed = EditorUtility.DisplayDialog(
                    "腳本樣板設定 Script Templates Setup",
                    "為了套用導入內容，須重新啟動 Unity 編輯器。\n\nTo apply imported content, you must restart Unity.",
                    "重新啟動 Restart", "稍後執行 Snooze");
                if (userConfirmed) {
                    EditorApplication.OpenProject(Environment.CurrentDirectory);
                }
            }
        }
    }
}