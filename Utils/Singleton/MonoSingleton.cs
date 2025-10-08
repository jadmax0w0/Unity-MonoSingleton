using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utils.Singleton
{
    public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T instance = null;

        private static bool isQuitting = false;

        public static T Instance
        {
            get
            {
                if (isQuitting)
                {
                    Debug.LogWarning($"The game is quitting now, but you are still getting an instance of {nameof(T)}");
                    return null;
                }

                TryInitializeWithGameObject();
                return instance;
            }
        }

        // If not created in the game scene in advance...

        private static void TryInitializeWithGameObject()
        {
            if (instance != null) return; // instance already initialized

            var go = new GameObject($"{typeof(T).Name}_Instance");
            instance = go.AddComponent<T>();
            DontDestroyOnLoad(go);
        }

        // If created in the game scene in advance...

        protected virtual void Awake()
        {
            if (instance != null && instance != this)
            {
                Destroy(this);
            }
            else if (instance == null)
            {
                instance = this as T;
                DontDestroyOnLoad(gameObject);
            }
        }

        // Destroy logics

        protected virtual void OnDestroy()
        {
            if (instance == this)
            {
                isQuitting = true;
            }
        }
    }
}
