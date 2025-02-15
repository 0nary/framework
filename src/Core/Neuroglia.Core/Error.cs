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

namespace Neuroglia
{

    /// <summary>
    /// Represents an error
    /// </summary>
    public class Error
    {

        /// <summary>
        /// Initializes a new <see cref="Error"/>
        /// </summary>
        protected Error()
        {

        }

        /// <summary>
        /// Initializes a new <see cref="Error"/>
        /// </summary>
        /// <param name="code">The <see cref="Error"/>'s code</param>
        /// <param name="message">The <see cref="Error"/>'s message</param>
        public Error(string code, string message)
        {
            this.Code = code;
            this.Message = message;
        }

        /// <summary>
        /// Initializes a new <see cref="Error"/>
        /// </summary>
        /// <param name="code">The <see cref="Error"/>'s code</param>
        public Error(string code)
            : this(code, null)
        {

        }

        /// <summary>
        /// Gets the <see cref="Error"/>'s code
        /// </summary>
        public virtual string Code { get; protected set; }

        /// <summary>
        /// Gets the <see cref="Error"/>'s message
        /// </summary>
        public virtual string Message { get; protected set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"{this.Code}: {this.Message}";
        }

    }

}
