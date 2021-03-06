using System.Collections;
using System;
using System.Collections.Generic;

namespace core{
    abstract class SyntaxNode{
        public abstract SyntaxKind Kind {get;}
        public abstract IEnumerable<SyntaxNode> GetChildren();
    }
    abstract class ExpressionSyntax : SyntaxNode{}

    sealed class NumberExpressionSyntax: ExpressionSyntax{
        public NumberExpressionSyntax(SyntaxToken numberToken){
            NumberToken = numberToken;
        }
        public override SyntaxKind Kind => SyntaxKind.NumberExpression;
        public override IEnumerable<SyntaxNode> GetChildren(){
            yield return NumberToken;
        }
        public SyntaxToken NumberToken {get;}    
    }

    sealed class BinaryExpressionSyntax: ExpressionSyntax{
        public BinaryExpressionSyntax(ExpressionSyntax left, SyntaxToken operatorToken, ExpressionSyntax right){
            Left = left;    
            Right = right;
            OperatorToken = operatorToken;
        }
        public override SyntaxKind Kind => SyntaxKind.BinaryExpression;
        public override IEnumerable<SyntaxNode> GetChildren(){
            yield return Left;
            yield return OperatorToken;
            yield return Right;
        }
        public ExpressionSyntax Left {get; }
        public ExpressionSyntax Right {get; }
        public SyntaxToken OperatorToken {get ;}
    }

    sealed class ParenthesizedExpressionSyntax: ExpressionSyntax{
        public ParenthesizedExpressionSyntax(SyntaxToken openParenthesis, ExpressionSyntax expression, SyntaxToken closeParenthesis){
            OpenParenthesis = openParenthesis;
            Expression = expression;
            CloseParenthesis = closeParenthesis;
        }

        public SyntaxToken OpenParenthesis {get;}
        public SyntaxToken CloseParenthesis {get;}
        public ExpressionSyntax Expression {get;}
        public override SyntaxKind Kind => SyntaxKind.BinaryExpression;
        public override IEnumerable<SyntaxNode> GetChildren(){
            yield return OpenParenthesis;
            yield return Expression;
            yield return CloseParenthesis;
        }


    }
    
}
