using UnityEngine;
namespace Toolkid.Core.Attribute {
    // 自定義屬性，用於存儲陣列標籤文字
    public class ArrayLabelAttribute : PropertyAttribute {
        public string label;
        public ArrayLabelAttribute(string label) => this.label = label;
    }
}