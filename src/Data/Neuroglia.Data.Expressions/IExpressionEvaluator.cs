﻿/*
 * Copyright © 2021 Neuroglia SPRL. All rights reserved.
 * <p>
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 * <p>
 * http://www.apache.org/licenses/LICENSE-2.0
 * <p>
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */

namespace Neuroglia.Data.Expressions
{

    /// <summary>
    /// Defines the fundamentals of a service used to evaluate expressions
    /// </summary>
    public interface IExpressionEvaluator
    {

        /// <summary>
        /// Determines whether or not the <see cref="IExpressionEvaluator"/> supports the specified expression language
        /// </summary>
        /// <param name="language">The expression language to check</param>
        /// <returns>A boolean indicating whether or not the <see cref="IExpressionEvaluator"/> supports the specified expression language</returns>
        bool Supports(string language);

        /// <summary>
        /// Evaluates the value of the specified serverless workflow expression
        /// </summary>
        /// <param name="expression">The serverless workflow expression to evaluate</param>
        /// <param name="data">The data to evaluate the specified expression against</param>
        /// <param name="expectedType">The expected data type</param>
        /// <param name="args">An <see cref="IDictionary{TKey, TValue}"/> containing the arguments to use when performing the evaluation</param>
        /// <returns>A new <see cref="object"/> that represents the resolved serverless workflow expression's value</returns>
        object? Evaluate(string expression, object data, Type expectedType, IDictionary<string, object>? args = null);

        /// <summary>
        /// Evaluates the value of the specified serverless workflow expression
        /// </summary>
        /// <param name="expression">The serverless workflow expression to evaluate</param>
        /// <param name="data">The data to evaluate the specified expression against</param>
        /// <param name="args">An <see cref="IDictionary{TKey, TValue}"/> containing the arguments to use when performing the evaluation</param>
        /// <returns>A new <see cref="object"/> that represents the resolved serverless workflow expression's value</returns>
        object? Evaluate(string expression, object data, IDictionary<string, object>? args = null);

        /// <summary>
        /// Evaluates the value of the specified serverless workflow expression
        /// </summary>
        /// <typeparam name="T">The expected type of data</typeparam>
        /// <param name="expression">The serverless workflow expression to evaluate</param>
        /// <param name="data">The data to evaluate the specified expression against</param>
        /// <param name="args">An <see cref="IDictionary{TKey, TValue}"/> containing the arguments to use when performing the evaluation</param>
        /// <returns>A new <see cref="object"/> that represents the resolved serverless workflow expression's value</returns>
        T? Evaluate<T>(string expression, object data, IDictionary<string, object>? args = null);

    }

}
