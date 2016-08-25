// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Microsoft.AspNetCore.Mvc.ModelBinding
{
    /// <summary>
    /// An abstraction used when grouping enum values for <see cref="ModelMetadata.EnumGroupedDisplayNamesAndValues"/>.
    /// </summary>
    public struct EnumGroupAndName
    {
        private Func<string> _nameFunc;

        /// <summary>
        /// Initializes a new instance of the EnumGroupAndName structure.
        /// </summary>
        /// <param name="group">The group name.</param>
        /// <param name="name">The name.</param>
        public EnumGroupAndName(string group, string name)
        {
            if (group == null)
            {
                throw new ArgumentNullException(nameof(group));
            }

            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            Group = group;
            _nameFunc = () => name;
        }

        public EnumGroupAndName(string group, Func<string> name)
        {
            if (group == null)
            {
                throw new ArgumentNullException(nameof(group));
            }

            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            Group = group;
            _nameFunc = name;
        }

        /// <summary>
        /// Gets the Group name.
        /// </summary>
        public string Group { get; }

        /// <summary>
        /// Gets the name.
        /// </summary>
        public string Name
        {
            get
            {
                return _nameFunc();
            }
        }
    }
}
