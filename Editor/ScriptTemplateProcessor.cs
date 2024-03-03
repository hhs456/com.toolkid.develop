using System;
using System.IO;
using UnityEditor;
using UnityEngine;

public class ScriptTemplateProcessor : AssetModificationProcessor {

    // �D�ϥΪ̾ާ@�Ӳ��͸귽�ɱN�|�I�s���禡�Aeg. ".meta" �ɮ�
    // �ݨϥ� static �׹���
    static void OnWillCreateAsset(string path) {
        // ����.meta extention�r��
        path = path.Replace(".meta", "");

        // �˴����|�����ɦW
        if (Path.GetExtension(path) != ".cs") {
            return;
        }
        
        // ���o�}�����|
        var index = Application.dataPath.LastIndexOf("Assets");
        path = Application.dataPath.Substring(0, index) + path;
        Debug.Log(path);
        // ���o�}���W��
        var fileName = Path.GetFileNameWithoutExtension(path);

        if (File.Exists(path)) {
            // �ഫ����r
            var content = File.ReadAllText(path);
            ReplaceKeyword(fileName, ref content);

            //// �мg�ɮרí��s��z�귽
            File.WriteAllText(path, content);
            AssetDatabase.Refresh();
        }
    }
    // �ഫ����r
    static void ReplaceKeyword(string fileName, ref string script) {        
        // �N���ɦW�� "Editor" �m���� "" �A�A�N���r����N "#TargetScriptName#"
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
                    "�}���˪O�]�w Script Templates Setup",
                    "���F�M�ξɤJ���e�A�����s�Ұ� Unity �s�边�C\n\nTo apply imported content, you must restart Unity.",
                    "���s�Ұ� Restart", "�y����� Snooze");
                if (userConfirmed) {
                    EditorApplication.OpenProject(Environment.CurrentDirectory);
                }
            }
        }
    }
}