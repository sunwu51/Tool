package main

import (
	"flag"
	"fmt"
	"github.com/gin-gonic/gin"
	"strconv"
)

func main() {

	port:=flag.Int("port",8081,"http port")
	assets:=flag.String("assets","assets","assets")


	flag.Parse()


	fmt.Println("port:", *port)
	fmt.Println("name:",*assets)

	router := gin.Default()
	router.Static("/", *assets)
	router.Run(":"+strconv.Itoa(*port))
	fmt.Println(*assets)
}
