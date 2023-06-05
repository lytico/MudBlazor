﻿// Copyright (c) MudBlazor 2021
// MudBlazor licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

// <auto-generated>
// This code was auto generated by a source code generator.
// </auto-generated>

namespace MudBlazor;

/// <summary>
/// Extension methods for <see cref="MudBlazor.ChartType"/> enum.
/// </summary>
public static class ChartTypeMudEnumExtensions {
    
    /// <summary>
    /// Returns the value of the <see cref="System.ComponentModel.DescriptionAttribute"/> attribute.
    /// If no description attribute was found the default ToString method will be used.
    /// </summary>
    public static string ToDescriptionString(this MudBlazor.ChartType mudEnum)
    {
        return mudEnum switch
        {
            _ => mudEnum.ToString().ToLower(),
        };

    }

}