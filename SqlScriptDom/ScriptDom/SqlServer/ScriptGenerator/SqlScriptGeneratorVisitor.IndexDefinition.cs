//------------------------------------------------------------------------------
// <copyright file="SqlScriptGeneratorVisitor.IndexDefinition.cs" company="Microsoft">
//         Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------
using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace Microsoft.SqlServer.TransactSql.ScriptDom.ScriptGenerator
{
    partial class SqlScriptGeneratorVisitor
    {
        public override void ExplicitVisit(IndexDefinition node)
        {
            if (_options.NewLineFormattedIndexDefinition)
            {
                AlignmentPoint start = new AlignmentPoint();
                MarkAndPushAlignmentPoint(start);
            }

            GenerateKeyword(TSqlTokenType.Index);

            if (node.Name != null)
            {
                GenerateSpaceAndFragmentIfNotNull(node.Name);       
            }

            if (node.Unique)
            {
                if (_options.NewLineFormattedIndexDefinition)
                {
                    NewLineAndIndent();
                }
                else
                {
                    GenerateSpace();
                }
                GenerateKeyword(TSqlTokenType.Unique);
            }

            if (node.IndexType != null)
            {
                switch (node.IndexType.IndexTypeKind)
                {
                    case IndexTypeKind.Clustered:
                        GenerateSpaceAndKeyword(TSqlTokenType.Clustered);                    
                        break;
                    case IndexTypeKind.NonClustered:
                        GenerateSpaceAndKeyword(TSqlTokenType.NonClustered);
                        break;
                    case IndexTypeKind.NonClusteredHash:
                        GenerateSpaceAndKeyword(TSqlTokenType.NonClustered);
                        GenerateSpaceAndIdentifier(CodeGenerationSupporter.Hash);
						break;
					case IndexTypeKind.ClusteredColumnStore:
                        GenerateSpaceAndKeyword(TSqlTokenType.Clustered);
                        GenerateSpaceAndIdentifier(CodeGenerationSupporter.ColumnStore);
						break;
					case IndexTypeKind.NonClusteredColumnStore:
                        GenerateSpaceAndKeyword(TSqlTokenType.NonClustered);
                        GenerateSpaceAndIdentifier(CodeGenerationSupporter.ColumnStore);
                        break;           
                }
            }

            if (node.Columns.Count > 0)
            {
                GenerateSpace();
                GenerateParenthesisedCommaSeparatedList(node.Columns);
            }

            if (node.IncludeColumns.Count > 0)
            {
                if (_options.NewLineFormattedIndexDefinition)
                {
                    NewLineAndIndent();
                }
                else
                {
                    GenerateSpace();
                }
                GenerateIdentifier(CodeGenerationSupporter.Include);
                GenerateSpace();
                GenerateParenthesisedCommaSeparatedList(node.IncludeColumns);
            }

			if (node.FilterPredicate != null)
			{
                if (_options.NewLineFormattedIndexDefinition)
                {
                    NewLineAndIndent();
                }
                else
                {
                    GenerateSpace();
                }
                GenerateKeyword(TSqlTokenType.Where);
                GenerateSpaceAndFragmentIfNotNull(node.FilterPredicate);
            }

            if (node.IndexOptions.Count > 0)
            {                            
                GenerateIndexOptions(node.IndexOptions);
            }
            
            if (node.OnFileGroupOrPartitionScheme != null)
            {
                NewLineAndIndent();
                GenerateKeyword(TSqlTokenType.On);

                GenerateSpaceAndFragmentIfNotNull(node.OnFileGroupOrPartitionScheme);
            }

            GenerateFileStreamOn(node);

            if (_options.NewLineFormattedIndexDefinition)
            {
                PopAlignmentPoint();
            }
        }
    }
}
