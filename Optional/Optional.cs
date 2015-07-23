// -----------------------------------------------------------------------
// <copyright file="Optional.cs" author="Vasilii Semenov" company="">
// </copyright>
// -----------------------------------------------------------------------

namespace OptionalDemo
{
	using System;

	/// <summary>
	/// Represents the generic optional reader
	/// </summary>
	/// <typeparam name="T">Expected return value type</typeparam>
	public sealed class Optional<T>
	{
		/// <summary>
		/// Assigned getter
		/// </summary>
		private Func<T> getHandler;

		/// <summary>
		/// Assigned error handler
		/// </summary>
		private Action<Exception> errorHandler;

		/// <summary>
		/// Instantiate the generic optional reader with a mapped getter
		/// </summary>
		/// <param name="getter">Method to get the value</param>
		/// <returns>New instance of generic optional reader with assigned getter</returns>
		public static Optional<T> Map(Func<T> getter)
		{
			return new Optional<T>()
			{
				getHandler = getter
			};
		}

		/// <summary>
		/// Assigns the error handler to the current instance of generic optional reader
		/// </summary>
		/// <param name="handler">External action to execute in case of exception. If the exception occurs during this handler call it will be thrown immediately.</param>
		/// <returns>Current instance of the optional reader</returns>
		public Optional<T> OnError(Action<Exception> handler)
		{
			this.errorHandler += handler;
			return this;
		}

		/// <summary>
		/// Invokes the getter and executes the error handler if assigned
		/// </summary>
		/// <returns>Result of getter invocation or default(T)</returns>
		public T Get()
		{
			try
			{
				var getter = this.getHandler;
				return getter == null ? default(T) : getter.Invoke();
			}
			catch (Exception exc)
			{
				var error = this.errorHandler;
				if (error != null)
				{
					error.Invoke(exc);
				}

				return default(T);
			}
		}

		/// <summary>
		/// Invokes the getter and executes the error handler if assigned
		/// </summary>
		/// <param name="value">Default value to return if the getter returned default(T)</param>
		/// <returns>Result of getter invocation or submitted default value</returns>
		public T GetOrDefault(T value)
		{
			T val = this.Get();

			return object.Equals(val, default(T)) ? value : val;
		}
	}

	/// <summary>
	/// Represents the optional reader
	/// </summary>
	public sealed class Optional
	{
		/// <summary>
		/// Method instatiates the generic optional reader
		/// </summary>
		/// <typeparam name="T">Expected return value type</typeparam>
		/// <param name="getter">Method to get the value</param>
		/// <returns>New instance of generic optional reader with assigned getter</returns>
		public static Optional<T> Map<T>(Func<T> getter)
		{
			return Optional<T>.Map(getter);
		}
	}
}
