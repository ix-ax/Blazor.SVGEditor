// Build
// Copyright (c) 2023 Peter Kurhajec (PTKu), MTS,  and Contributors. All Rights Reserved.
// Contributors: https://github.com/ix-ax/ix/graphs/contributors
// See the LICENSE file in the repository root for more information.
// https://github.com/ix-ax/ix/blob/master/LICENSE
// Third party licenses: https://github.com/ix-ax/ix/blob/master/notices.md

using Polly;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

internal class Helpers
{
    public static readonly IEnumerable<string> PublishInternal = new List<string>() { "dev", "main", "master", "release" };
    public static readonly IEnumerable<string> PublishExternal = new List<string>() { "main", "master", "release" };

    public static bool CanReleaseInternal()
    {
        return PublishInternal.Any(predicate =>
            predicate == GitVersionInformation.BranchName ||
            GitVersionInformation.BranchName.StartsWith("releases/"));
    }

    public static bool CanReleasePublic()
    {
        return PublishExternal.Any(predicate =>
            predicate == GitVersionInformation.BranchName ||
            GitVersionInformation.BranchName.StartsWith("releases/"));
    }
}
