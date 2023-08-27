## Toolkid.EditorToolkits

This repository offers a collection of custom attributes designed to simplify operations in Unity's Inspector.

### LabelAttribute

`LabelAttribute` allows you to display custom names for fields in Unity's Inspector.

#### How to Use

Add `[Label("Your Custom Name")]` before the field you want to display with a custom name.

```csharp
public class Example : MonoBehaviour
{
    [Label("Health Points")]
    public int health;
}
```

With this, the field will display as "Health Points" in Unity's Inspector, instead of the default "health".

### ReadOnlyAttribute

`ReadOnlyAttribute` enables you to set fields in Unity's Inspector to read-only.

#### How to Use

Add `[ReadOnly]` before the field you want to set as read-only.

```csharp
public class Example : MonoBehaviour
{
    [ReadOnly]
    public int readOnlyField;
}
```

This way, the field will be uneditable in Unity's Inspector and will be read-only.

### Notes

When using the Label attribute, note that Unity's `PropertyDrawer` API does not directly support custom drawing of arrays. This attribute attempts to determine whether it is an element of an array by parsing the property's path and appending an index to the label name. However, this approach will not change the label name of the entire array, only the label names of the array elements.

If you find a better way to customize the drawing of arrays, or have any suggestions and feedback, feel free to contact me. Your contributions will help improve this toolkit and benefit more Unity developers.
