package top.microfrank;
import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.net.InetSocketAddress;
import java.net.UnknownHostException;
import java.util.Collection;

import org.java_websocket.WebSocket;
import org.java_websocket.WebSocketImpl;
import org.java_websocket.framing.Framedata;
import org.java_websocket.handshake.ClientHandshake;
import org.java_websocket.server.WebSocketServer;



public class Wsserver extends WebSocketServer{

	public Wsserver(int port) throws UnknownHostException {
		super( new InetSocketAddress( port ) );
		// TODO Auto-generated constructor stub
	}
	public Wsserver( InetSocketAddress address ) {
		super( address );
	}

	public static void main(String[] args) throws UnknownHostException {
		// TODO Auto-generated method stub
		int port = 1234; // 843 flash policy port
		try {
			port = Integer.parseInt( args[ 0 ] );
		} catch ( Exception ex ) {
		}
		new Wsserver(port).start();
	}

	@Override
	public void onClose(WebSocket arg0, int arg1, String arg2, boolean arg3) {
		// TODO Auto-generated method stub
		
	}

	@Override
	public void onError(WebSocket arg0, Exception arg1) {
		// TODO Auto-generated method stub
		
	}

	@Override
	public void onMessage(WebSocket arg0, String arg1) {
		// TODO Auto-generated method stub
		print(arg1);
		arg0.send(arg1);
		
	}

	@Override
	public void onOpen(WebSocket arg0, ClientHandshake arg1) {
		// TODO Auto-generated method stub
		
	}
	public void print(Object obj){
		System.out.println(obj);
	}

}
