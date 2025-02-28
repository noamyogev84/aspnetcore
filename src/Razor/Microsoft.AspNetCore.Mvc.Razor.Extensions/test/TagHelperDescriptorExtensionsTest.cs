﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Microsoft.AspNetCore.Razor.Language;
using Xunit;

namespace Microsoft.AspNetCore.Mvc.Razor.Extensions
{
    public class TagHelperDescriptorExtensionsTest
    {
        [Fact]
        public void IsViewComponentKind_ReturnsFalse_ForNonVCTHDescriptor()
        {
            // Arrange
            var tagHelper = CreateTagHelperDescriptor();

            // Act
            var result = tagHelper.IsViewComponentKind();

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void IsViewComponentKind_ReturnsTrue_ForVCTHDescriptor()
        {
            // Arrange
            var tagHelper = CreateViewComponentTagHelperDescriptor();

            // Act
            var result = tagHelper.IsViewComponentKind();

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void GetViewComponentName_ReturnsNull_ForNonVCTHDescriptor()
        {
            //Arrange
            var tagHelper = CreateTagHelperDescriptor();

            // Act
            var result = tagHelper.GetViewComponentName();

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void GetViewComponentName_ReturnsName_ForVCTHDescriptor()
        {
            // Arrange
            var tagHelper = CreateViewComponentTagHelperDescriptor("ViewComponentName");

            // Act
            var result = tagHelper.GetViewComponentName();

            // Assert
            Assert.Equal("ViewComponentName", result);
        }

        private static TagHelperDescriptor CreateTagHelperDescriptor()
        {
            var tagHelper = TagHelperDescriptorBuilder.Create("TypeName", "AssemblyName")
                .TagMatchingRuleDescriptor(rule => rule.RequireTagName("tag-name"))
                .Build();

            return tagHelper;
        }

        private static TagHelperDescriptor CreateViewComponentTagHelperDescriptor(string name = "ViewComponentName")
        {
            var tagHelper = TagHelperDescriptorBuilder.Create(ViewComponentTagHelperConventions.Kind, "TypeName", "AssemblyName")
                .TagMatchingRuleDescriptor(rule => rule.RequireTagName("tag-name"))
                .AddMetadata(ViewComponentTagHelperMetadata.Name, name)
                .Build();

            return tagHelper;
        }
    }
}