## Toolkid.EditorToolkits

這個儲存庫提供了一系列用於簡化Unity Inspector操作的自定義Attributes。

### LabelAttribute

`LabelAttribute`允許您在Unity Inspector中為欄位（Field）顯示自定義名稱。

#### 使用方法

在您想要自定義顯示名稱的欄位前添加`[Label("您的自定義名稱")]`。

```csharp
public class Example : MonoBehaviour
{
    [Label("生命值")]
    public int health;
}
```

這樣，在Unity Inspector中，這個字段將顯示為"生命值"，而不是默認的"health"。

### ReadOnlyAttribute

`ReadOnlyAttribute`讓您能夠將Unity Inspector中的欄位設置為唯讀。

#### 使用方法

在您想要設置為唯讀的欄位前添加`[ReadOnly]`。

```csharp
public class Example : MonoBehaviour
{
    [ReadOnly]
    public int readOnlyField;
}
```

如此一來，在Unity Inspector中，這個欄位將不能被編輯，僅供閱讀使用。

### 注意事項

在使用 Label 屬性時，請注意 Unity 的 `PropertyDrawer` API 不直接支援陣列的自定義繪製。這個屬性嘗試通過解析屬性的路徑來判斷它是否是陣列的元素，並且添加索引到標籤名稱。然而，這個方法不會改變整個陣列的標籤名稱，只會改變陣列元素的標籤名稱。

如果你找到了更好的方法來自定義陣列的繪製，或者有任何建議和反饋，請隨時與我聯繫。你的貢獻將有助於改善這個工具包，並且讓更多的 Unity 開發者受益。
