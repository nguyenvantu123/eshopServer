using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ordering.API.Extensions
{
    public static class LinqSelectExtensions
    {

        public static IEnumerable<SelectTryResult<TSource, TResult>> SelectTry<TSource, TResult>(this IEnumerable<TSource> enumarable, Func<TSource, TResult> selector)
        {
            foreach (TSource element in enumarable)
            {
                SelectTryResult<TSource, TResult> returnedValue;

                try
                {
                    returnedValue = new SelectTryResult<TSource, TResult>(element, selector(element), null);
                }
                catch (Exception ex)
                {

                    returnedValue = new SelectTryResult<TSource, TResult>(element, default(TResult), ex);
                }

                yield return returnedValue;
            }
        }

        public static IEnumerable<TResult> OnCaughtException<TSource, TResult>(this IEnumerable<SelectTryResult<TSource, TResult>> enumarable, Func<Exception, TResult> exceptionHandler)
        {
            return enumarable.Select(x => x.Exception == null ? x.Result : exceptionHandler(x.Exception));
        }

        public static IEnumerable<TResult> OnCaughtException<TSource, TResult>(this IEnumerable<SelectTryResult<TSource, TResult>> enumarable, Func<TSource, Exception, TResult> exceptionHandler)
        {
            return enumarable.Select(x => x.Exception == null ? x.Result : exceptionHandler(x.Source, x.Exception));
        }

        public class SelectTryResult<TSource, TResult>
        {
            public TSource Source { get; private set; }
            public TResult Result { get; private set; }

            public Exception Exception { get; private set; }

            internal SelectTryResult(TSource source, TResult result, Exception exception)
            {
                Source = source;
                Result = result;
                Exception = exception;
            }
        }
    }
}
