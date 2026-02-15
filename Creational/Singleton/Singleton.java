public class Singleton {

    // ?? WHY VOLATILE
    // => Visibility Guarantee (Thread A sees always latest value, not cached
    // value)[Loads from Main Memory]
    // => Maintain Ordering while instance is created [Allocate Memory, Intialize
    // Object, Assign Reference]
    private static volatile Singleton instance;
    // Add Your Attributes Required For Singleton
    String data; // Example

    private Singleton(String data) {
        this.data = data;
    }

    public static Singleton getInstance(String data) {

        // To avoid executing the sync block everytime we can check the
        // whether instance is already created or not
        if (instance == null) {
            synchronized (Singleton.class) {
                if (instance == null) {
                    instance = new Singleton(data);
                }
            }
        }
        return instance;
    }

    public void printData() {
        System.out.println(data);
    }

    public static void main(String[] args) {
        // You can play around by creating objects to understand it!!
    }

}