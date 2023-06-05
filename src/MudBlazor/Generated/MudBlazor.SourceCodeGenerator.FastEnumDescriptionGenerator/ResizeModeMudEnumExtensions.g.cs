﻿// Copyright (c) MudBlazor 2021
// MudBlazor licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

// <auto-generated>
// This code was auto generated by a source code generator.
// </auto-generated>

namespace MudBlazor;

/// <summary>
/// Extension methods for <see cref="MudBlazor.ResizeMode"/> enum.
/// </summary>
public static class ResizeModeMudEnumExtensions {
    
    /// <summary>
    /// Returns the value of the <see cref="System.ComponentModel.DescriptionAttribute"/> attribute.
    /// If no description attribute was found the default ToString method will be used.
    /// </summary>
    public static string ToDescriptionString(this MudBlazor.ResizeMode mudEnum)
    {
        return mudEnum switch
        {
            MudBlazor.ResizeMode.None => "none",
            MudBlazor.ResizeMode.Column => "column",
            MudBlazor.ResizeMode.Container => "container",
            _ => mudEnum.ToString().ToLower(),
        };

    }

}