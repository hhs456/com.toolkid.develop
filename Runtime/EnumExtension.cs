using System;
using System.ComponentModel;
using System.Reflection;
using System.Linq;
using UnityEngine;

namespace Toolkid
{
    public static class EnumExtension
    {
        public static string GetInspectorName(this Enum enumValue) {
            Type type = enumValue.GetType();
            string name = enumValue.ToString().Replace(" ","");
            string[] names = name.Split(',');
            int size = names.Length;
            for (int i = 0; i < size; i++) {
             var field = type.GetField(names[i]);
                var attributes = field.GetCustomAttributes<InspectorNameAttribute>();
                if (i > 0) {
                    name += ", ";
                }
                name += attributes.FirstOrDefault()?.displayName ?? string.Empty;
            }            
            return name;
        }

        public static string[] GetInspectorNames(this Enum enumValue) {
            Type type = enumValue.GetType();            
            string[] names = Enum.GetNames(type);
            int size = names.Length;
            for (int i = 0; i < size; i++) {
                var field = type.GetField(names[i]);
                var attributes = field.GetCustomAttributes<InspectorNameAttribute>();                
                names[i] = attributes.FirstOrDefault()?.displayName ?? string.Empty;
            }
            return names;
        }
    }
}
