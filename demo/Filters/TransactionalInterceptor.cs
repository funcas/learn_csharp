using System;
using System.Reflection;
using System.Transactions;
using Castle.DynamicProxy;

namespace demo.Filters
{
	public class TransactionalInterceptor : IInterceptor
    {
        //可自行实现日志器，此处可忽略
        /// <summary>
        /// 日志记录器
        /// </summary>
        //private static readonly ILog Logger = Log.GetLog(typeof(TransactionInterceptor));

        // 是否开发模式
        private bool isDev = false;
        public void Intercept(IInvocation invocation)
        {
            if (!isDev)
            {
                MethodInfo methodInfo = invocation.MethodInvocationTarget;
                if (methodInfo == null)
                {
                    methodInfo = invocation.Method;
                }

                TransactionalAttribute transaction =
                    methodInfo.GetCustomAttributes<TransactionalAttribute>(true).FirstOrDefault();
                if (transaction != null)
                {
                    TransactionOptions transactionOptions = new TransactionOptions();
                    //设置事务隔离级别
                    transactionOptions.IsolationLevel = transaction.IsolationLevel;
                    //设置事务超时时间为60秒
                    transactionOptions.Timeout = new TimeSpan(0, 0, transaction.Timeout);
                    using (TransactionScope scope = new TransactionScope(transaction.ScopeOption, transactionOptions))
                    {
                        try
                        {
                            //实现事务性工作
                            invocation.Proceed();
                            scope.Complete();
                        }
                        catch (Exception)
                        {
                            
                            // 记录异常
                            throw;
                        }
                    }
                }
                else
                {
                    // 没有事务时直接执行方法
                    invocation.Proceed();
                }
            }
            else
            {
                // 开发模式直接跳过拦截
                invocation.Proceed();
            }
        }
    }
}

