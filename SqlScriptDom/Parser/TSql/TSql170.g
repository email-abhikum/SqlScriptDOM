                ( Comma
                    (
                        vLiteral=integer
                        {
                            AddAndUpdateTokenInfo(vParent, vParent.Parameters, vLiteral);
                        }
                    |
                        vLiteral=identifierLiteral
                        {
                            AddAndUpdateTokenInfo(vParent, vParent.Parameters, vLiteral);
                        }
                    )
