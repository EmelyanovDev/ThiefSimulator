using UnityEngine;

namespace Utilities
{
    public class Singleton<TSource> : MonoBehaviour where TSource : MonoBehaviour
    {
        private static TSource _instance;
        
        public static TSource Instance
        {
            get
            {
                if (_instance != null) 
                    return _instance;
                
                _instance = FindObjectOfType<TSource>();
                
                if (_instance == null) 
                    throw new MissingComponentException("Component not found.");
                
                return _instance;
            }
        }
    }
}