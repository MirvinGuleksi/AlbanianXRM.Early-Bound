﻿using System.CodeDom;
using System.Collections.Generic;

namespace AlbanianXrm.CrmSvcUtilExtensions.Extensions
{
    public static class CollectionExtensions
    {
        public static IEnumerable<CodeTypeDeclaration> ToEnumerable(this CodeTypeDeclarationCollection collection)
        {
            foreach (CodeTypeDeclaration codeTypeDeclaration in collection)
            {
                yield return codeTypeDeclaration;
            }
        }

        public static IEnumerable<CodeTypeMember> ToEnumerable(this CodeTypeMemberCollection collection)
        {
            foreach (CodeTypeMember codeTypeMember in collection)
            {
                yield return codeTypeMember;
            }
        }

        public static IEnumerable<T> ToEnumerable<T>(this CodeTypeMemberCollection collection) where T : CodeTypeMember
        {
            foreach (CodeTypeMember codeTypeMember in collection)
            {
                if (codeTypeMember is T tMember)
                {
                    yield return tMember;
                }
            }
        }
    }
}
