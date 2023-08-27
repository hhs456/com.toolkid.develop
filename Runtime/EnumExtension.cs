using System;
using System.ComponentModel;
using System.Reflection;
using System.Linq;
using UnityEngine;
using System.Collections.Generic;

namespace Toolkid
{
    public static class EnumExtension
    {
        public static string GetInspectorName(this Enum enumValue) {
            Type type = enumValue.GetType();
            string[] names = enumValue.ToString().Split(',');
            var displayNameList = new List<string>();

            foreach (var name in names) {
                var field = type.GetField(name.Trim());
                if (field == null) {
                    Debug.LogWarning($"Field not found for enum value: {name}");
                    continue;
                }

                var attributes = field.GetCustomAttributes<InspectorNameAttribute>();
                var displayName = attributes.FirstOrDefault()?.displayName;

                if (string.IsNullOrEmpty(displayName)) {
                    Debug.LogWarning($"InspectorNameAttribute not found for enum value: {name}");
                    displayNameList.Add(name); // Use the original name if no attribute found
                }
                else {
                    displayNameList.Add(displayName);
                }
            }

            return string.Join(", ", displayNameList);
        }


        public static string[] GetInspectorNames(this Enum enumValue) {
            Type type = enumValue.GetType();
            string[] names = Enum.GetNames(type);
            int size = names.Length;

            for (int i = 0; i < size; i++) {
                var field = type.GetField(names[i]);
                if (field == null) {
                    Debug.LogWarning($"Field not found for enum value: {names[i]}");
                    continue; // Keep the original name if the field is not found
                }

                var attributes = field.GetCustomAttributes<InspectorNameAttribute>();
                var displayName = attributes.FirstOrDefault()?.displayName;

                if (string.IsNullOrEmpty(displayName)) {
                    Debug.LogWarning($"InspectorNameAttribute not found for enum value: {names[i]}");
                    // Keep the original name if no attribute found
                }
                else {
                    names[i] = displayName;
                }
            }

            return names;
        }

    }
}
