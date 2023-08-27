using UnityEngine;

namespace Toolkid.Core.Attribute {
    // 自定義屬性，用於存儲標籤文字
    public class LabelAttribute : PropertyAttribute {
        public string label;
        public bool expanded;

        public LabelAttribute(string label, bool expanded = true) {
            this.label = label;
            this.expanded = expanded;
        }
    }
}