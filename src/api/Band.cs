// Copyright 2010 Green Code LLC
// All rights reserved.
//
// The copyright holders license this file under the New (3-clause) BSD
// License (the "License").  You may not use this file except in
// compliance with the License.  A copy of the License is available at
//
//   http://www.opensource.org/licenses/BSD-3-Clause
//
// and is included in the NOTICE.txt file distributed with this work.
//
// Contributors:
//   James Domingo, Green Code LLC

namespace Landis.SpatialModeling
{
    /// <summary>
    /// A pixel band of a particular data type.
    /// </summary>
    public class Band<T> : PixelBand
        where T : struct
    {
        /// <summary>
        /// The value of the pixel band.
        /// </summary>
        public T Value { get; set; }

        /// <summary>
        /// Constructs a new pixel band from its description.
        /// <example>
        ///   Band<float> Slope = "slope : tangent of inclination angle (rise/run)";
        /// </example>
        /// </summary>
        /// <param name="description">
        /// A <see cref="System.String"/>
        /// </param>
        /// <returns>
        /// A <see cref="Band<T>"/>
        /// </returns>
        public static implicit operator Band<T>(string description)
        {
            return new Band<T>(description);
        }

        private Band(string description)
            : base(description, System.Type.GetTypeCode(typeof(T)))
        {
        }

        /// <summary>
        /// Computes the size in bytes for a pixel band's data type.
        /// </summary>
        /// <param name="typeCode">
        /// A <see cref="System.TypeCode"/> representing the pixel band's data
        /// type.
        /// </param>
        /// <returns>
        /// A <see cref="System.Int32"/>
        /// </returns>
        /// <exception cref="System.ArgumentException">Thrown if
        /// <paramref name="typeCode"/> is not Byte, SByte, Int16, UInt16,
        /// Int32, UInt32, Single or Double.
        /// </exception>
        public static int ComputeSize()
        {
            return PixelBand.ComputeSize(System.Type.GetTypeCode(typeof(T)));
        }
    }
}
