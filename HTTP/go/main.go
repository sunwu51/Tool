package main

import (
	"github.com/gin-gonic/gin"
	//"fmt"
	"fmt"
)

func main() {
	r := gin.Default()

	r.Any("/", func(c *gin.Context) {
		c.String(200,"hello world")
	})

	r.Any("/json", func(c *gin.Context) {
		c.JSON(200,gin.H{"foo":"bar"})
	})

	r.POST("/echo", func(c *gin.Context) {
		var amap  interface{}
		c.BindJSON(&amap)
		fmt.Println(amap)
		if(amap!=nil){
			c.JSON(200,amap)
		} else {
			c.JSON(400,gin.H{"error":"not json content-type"})
		}
	})

	r.Run(":8007") // listen and serve on 0.0.0.0:8007
}
