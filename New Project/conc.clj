(def friends1 (ref ()))
(def friends2 (ref ()))
(defn method1 []
    (dosync
        (println "starting method1")
        (alter friends1 conj "Stu")
        (println (str "in method1" @friends1 @friends2 "~~~"))
        (alter friends2 conj "Bob")
        (println (str "in method1" @friends1 @friends2 "~~~"))
        (println "ending method1")
    )
) 
(defn method2 []
    (dosync
        (println "starting method2")
        (alter friends1 conj "Sara")
        (println (str "in method2" @friends1 @friends2 "~~~"))
        (alter friends2 conj "Nancy")
        (println (str "in method2" @friends1 @friends2 "~~~"))
        (println "ending method2")
    )
)
(.start (Thread. (fn[] (method1))))
(.start (Thread. (fn[] (method2))))